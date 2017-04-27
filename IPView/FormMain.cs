using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;

namespace IPView
{
    public partial class FormMain : Form
    {
        //Поля для хранения начального и конечного адресов диапазона
        private IPAddress StartIP;
        private IPAddress FinishIP;
        private CancellationTokenSource cts;
        private CancellationToken token;

        public FormMain()
        {
            InitializeComponent();
            //Дефолтные значения:
            StartIP = IPAddress.Parse("127.0.0.1");
            FinishIP = IPAddress.Parse("127.0.0.255");
            tbStartIP.Text = StartIP.ToString();
            tbFinishIP.Text = FinishIP.ToString();
        }

        //Метод итерации адресов с помещением их в GUI (для асинхронной работы)
        private Task GetIPAddresses(IPAddress Start, IPAddress Finish, CancellationToken token)
        {
            //Формируем Action для задачи как ананимную функцию:
            return Task.Factory.StartNew(() =>
            {
                //Представление адресов в виде массива байт
                byte[] StartIPAsBytes = StartIP.GetAddressBytes();
                byte[] FinishIPAsBytes = FinishIP.GetAddressBytes();

                //Делаем реверсирование массива с байтами адресов
                Array.Reverse(StartIPAsBytes);
                Array.Reverse(FinishIPAsBytes);

                //Конвертируем в беззнаковое целое
                uint uint_StartIP = BitConverter.ToUInt32(StartIPAsBytes, 0);
                uint uint_FinishIP = BitConverter.ToUInt32(FinishIPAsBytes, 0);

                //Чистим текст-бокс на главной форме
                DoGuiOut(tbIpList, lb => lb.Clear());

                //А вот теперь можем запускать цикл, в котором перебираем адреса 
                for (var i = uint_StartIP; i <= uint_FinishIP; i++)
                {
                    //Выполняем обратные преобразования - увеличенный на единицу итератор конвертируем в массив байт
                    var bytes = BitConverter.GetBytes(i);
                    //Восстанавливаем нормальный порядок следования байт
                    Array.Reverse(bytes);
                    //Генерим полученный адрес
                    var Ip = new IPAddress(bytes);
                    //Выводим адрес в форму
                    if (token.IsCancellationRequested)
                    {
                        DoGuiOut(tbIpList, tb => tb.AppendText($"Операция прервана. Число адресов: {tb.Lines.LongCount()}\n"));
                        return;
                    }
                    DoGuiOut(tbIpList, tb => tb.AppendText(Ip.ToString()+"\n"));
                }
                //Выводим полученное число элементов
                DoGuiOut(tbIpList, tb => tb.AppendText($"\nЗавершено. Число адресов: {tb.Lines.LongCount()}\n"));
            });
        }

        private static void DoGuiOut<TControl>(TControl control, Action<TControl> action) where TControl : Control
        {
            //Делаем потокобезопасный вывод в интерфейс
            if (control.InvokeRequired)
            {
                //Вызываем переданный Action в потоке контрола, если это необходимо
                control.Invoke(action, control);
            }
            else
            {
                //Просто вызываем переданный делегат
                action(control);
            }
        }

        //Этот метод остался из однопоточной версии программы
        public IEnumerable<IPAddress> GetIPAddressesRange(IPAddress StartIP, IPAddress FinishIP)
        {
            byte[] StartIPAsBytes = StartIP.GetAddressBytes();
            byte[] FinishIPAsBytes = FinishIP.GetAddressBytes();

            Array.Reverse(StartIPAsBytes);
            Array.Reverse(FinishIPAsBytes);

            uint uint_StartIP = BitConverter.ToUInt32(StartIPAsBytes, 0);
            uint uint_FinishIP = BitConverter.ToUInt32(FinishIPAsBytes, 0);

            for (var i = uint_StartIP; i <= uint_FinishIP; i++)
            {
                var bytes = BitConverter.GetBytes(i);
                Array.Reverse(bytes);
                var newIp = new IPAddress(bytes);
                yield return newIp;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            //Попытка выхода
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Запрос на выход
            if (DialogResult.Yes != MessageBox.Show("Завершить работу?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                e.Cancel = true;
            }
            else
            {
                cts.Cancel();
            }
        }

        private async void buttonStart_Click(object sender, EventArgs e)
        {
            //Проверим границы указанного диапазона
            byte[] StartIPAsBytes = StartIP.GetAddressBytes();
            byte[] FinishIPAsBytes = FinishIP.GetAddressBytes();

            Array.Reverse(StartIPAsBytes);
            Array.Reverse(FinishIPAsBytes);

            uint uint_StartIP = BitConverter.ToUInt32(StartIPAsBytes, 0);
            uint uint_FinishIP = BitConverter.ToUInt32(FinishIPAsBytes, 0);

            if (uint_StartIP > uint_FinishIP)
            {
                MessageBox.Show("Адрес начала диапазона больше, чем адрес окончания диапазона.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            
            tbIpList.Clear();
            cts = new CancellationTokenSource();
            token = cts.Token;

            //Операции с кнопками
            if (sender is Button)
                (sender as Button).Enabled = false;
            buttonStop.Visible = true;

            //Ниже закомменчен однопоточный вариант
            //var ip = GetIPAddressesRange(StartIP, FinishIP);
            //var s = string.Empty;
            //foreach (var Addr in ip)
            //{
            //    s = Addr.ToString();
            //    tbIpList.AppendText(s+"\n");
            //}

            //tbIpList.AppendText($"Завершено. Адресов: {ip.LongCount()}");
            
            //Асинхронный вызов таска по перечислению адресов
            await GetIPAddresses(StartIP, FinishIP, token);

            //Вновь включаем кнопку
            buttonStop.Visible = false;
            if (sender is Button)
                (sender as Button).Enabled = true;
        }

        private void tbIP_Validating(object sender, CancelEventArgs e)
        {
            //Валидатор вводимых IP
            //Можно было использовать специальный контрол для ввода IP-адресов:
            //https://github.com/m66n/ipaddresscontrollib/tree/master/source
            TextBox tb;
            if (sender is TextBox)
            {
                tb = sender as TextBox;
                //Помимо проверки через конвертацию, нужно еще проверить наличие точек, т.к. значения вида 314 или 34567 свободно проходят конвертацию.
                //Потому посчитаем точки в IP-адресе, их должно быть 3.
                int dot_count = tb.Text.Length - tb.Text.Replace(".", "").Length;
                if (dot_count != 3)
                {
                    e.Cancel = true;
                }
                else
                {
                    //Проверка через попытку конвертации
                    IPAddress IpAddr = IPAddress.Parse("127.0.0.1");
                    e.Cancel = !IPAddress.TryParse(tb.Text, out IpAddr);
                }

                //Цветовое оформление
                if (e.Cancel)
                    tb.BackColor = Color.IndianRed;// .OrangeRed;
                else
                    tb.BackColor = SystemColors.Window;
            }
            else
                e.Cancel = false;
        }

        private void tbIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Обработчик клавиатуры для текст-боксов с адресами начала и окончания диапазонов
            var key = e.KeyChar;
            if (key == 27) //Обработка ESC и восстановление предыдущих корректных значений адресов
            {
                if (sender is TextBox)
                {
                    int fieldNo = (sender as TextBox).Tag == null ? -1 : Convert.ToInt32((sender as TextBox).Tag);
                    string s = string.Empty;
                    switch (fieldNo)
                    {
                        case 0:
                            s = StartIP.ToString();
                            break;
                        case 1:
                            s = FinishIP.ToString();
                            break;
                        default:
                            break;
                    }
                    if (s != string.Empty)
                        (sender as TextBox).Text = s;
                }

            }
            if (!char.IsDigit(key) && key != 8 && key != 46) // цифры, BS, точка
            {
                e.Handled = true;
            }
        }

        private void tbIP_Validated(object sender, EventArgs e)
        {
            //Проверка корректности прошла - обновляем поля с границами диапазона
            if (sender is TextBox)
            {
                TextBox tb = sender as TextBox;
                IPAddress Addr = IPAddress.Parse(tb.Text);
                int fieldNo = tb.Tag == null ? -1 : Convert.ToInt32(tb.Tag);
                switch (fieldNo)
                {
                    case 0:
                        StartIP = Addr;
                        break;
                    case 1:
                        FinishIP = Addr;
                        break;
                    default:
                        break;
                }
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }
    }
}
