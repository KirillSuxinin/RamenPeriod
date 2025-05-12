using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ViewerT
{
    /// <summary>
    /// Логика взаимодействия для ViewerTable.xaml
    /// </summary>
    public partial class ViewerTable : UserControl
    {
        private HandlerProduct ACT_ADD;
        private HandlerProduct ACT_DEL;
        private HandlerProduct ACT_EDIT;
        private HandlerProduct ACT_ABOUT;

        public ViewerTable(List<MeProducts> products, HandlerProduct act_add,HandlerProduct act_about, HandlerProduct act_edit, HandlerProduct act_del)
        {
            InitializeComponent();
            this.ACT_ADD = act_add;
            this.ACT_DEL = act_del;
            this.ACT_ABOUT = act_about;
            this.ACT_EDIT = act_edit;
            this.DataContext = new ViewerTable_ViewModel(products);
        }


        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button)
            {
                string update_context = ACT_ADD?.Invoke(int.Parse((sender as Button).Tag.ToString()),sender);

                if (update_context != string.Empty)
                {
                    (sender as Button).Content = update_context;
                }

            }
            else if(sender is MenuItem)
            {
                ACT_ADD?.Invoke(MouseProduct.IdProduct,sender);
                
            }
        }

        private MeProducts MouseProduct;

        private void btn_about_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                ACT_ABOUT?.Invoke(int.Parse((sender as Button).Tag.ToString()), sender);

            }
            else if (sender is MenuItem)
            {
                ACT_ABOUT?.Invoke(MouseProduct.IdProduct, sender);
            }
        }

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            MouseProduct = (sender as StackPanel).DataContext as MeProducts;

        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button)
            {
                ACT_DEL?.Invoke(int.Parse((sender as Button).Tag.ToString()), sender);
            }
            else if (sender is MenuItem)
            {
                ACT_DEL?.Invoke(MouseProduct.IdProduct, sender);
            }
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public delegate string HandlerProduct(int id_product,object sender);

    public class MeProducts : INotifyPropertyChanged
    {
        /// <summary>
        /// Метод получение изображения
        /// </summary>
        /// <param name="IURL">URL - Адрес изображение как локальный так и из сети</param>
        /// <returns></returns>
        private static Bitmap GetBitmap(string IURL)
        {
            try
            {
                //Экземпляр WebClient (Встроенный класс для примитивной работы с HTTP протоколом)
                WebClient web = new WebClient();
                //Скачиваем массив байтов по ссылке (И не важно удалённый или локальный адрес)
                byte[] dat = web.DownloadData(IURL);
                //Массив байт переводим в поток MemoryStream из System.IO и используем метод FromStream класса Image
                //И делаем привидение типа Image к Bitmap (полеморфизм) и возращаем Bitmap
                return (Bitmap)System.Drawing.Image.FromStream(new MemoryStream(dat));
            }
            //Исключение если мало прав (нету доступа для выделения потока)
            catch (NotSupportedException g)
            {
             //   Debugger.Log(1, PATHCODE.WARNING, $"Ошибка потока. Войдите как администратор.\n{g}");
            }
            //Исключение нету интернета или доступа фаервол
            catch (WebException g)
            {
              //  Debugger.Log(1, PATHCODE.WARNING, $"Ошибка подключение к интернету!\n{g}");
            }
            //Остальные исключение которые могут возникнуть, не вызываем CRITICAL а вернём избр. вшитое
            catch (Exception g)
            {
               // Debugger.Log(0, PATHCODE.ERROR, g, typeof(Program));
            }
            //Возвращаяем избр. по умолчанию
            return null;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        private string image_url;
        public BitmapImage ImageProduct
        {
            get
            {
                BitmapImage bt = new BitmapImage();
                var bitm = GetBitmap(image_url);
                using (MemoryStream memory = new MemoryStream())
                {
                    bitm.Save(memory, ImageFormat.Png);
                    memory.Position = 0;
                    bt = new BitmapImage();
                    bt.BeginInit();
                    bt.StreamSource = memory;
                    bt.CacheOption = BitmapCacheOption.OnLoad;
                    bt.EndInit();
                }
                return bt;
            }
            set
            {
                OnPropertyChanged("ImageProduct");

            }
        }

        private int _IdProduct;

        public int IdProduct
        {
            get
            {
                return _IdProduct;
            }
            set
            {
                OnPropertyChanged("IdProduct");
                _IdProduct = value;
            }
        }

        private int _CountAdded;


        private Visibility _DelBtn = Visibility.Visible;
        public Visibility DelVisible
        {
            get
            {
                return _DelBtn;
            }
            set
            {
                OnPropertyChanged("DelVisible");
                _DelBtn = value;
            }

        }



        private Visibility _EditVisible = Visibility.Visible;
        public Visibility EditVisible
        {
            get
            {
                return _EditVisible;
            }
            set
            {
                OnPropertyChanged("EditVisible");
                _EditVisible = value;
            }

        }

        public string CountAdded
        {
            get
            {
                return $"Добавить ({_CountAdded})";
            }
            set
            {
                OnPropertyChanged("CountAdded");
                _CountAdded = int.Parse(value);
            }
        }

        public void Set_Image_Url(string url)
        {
            image_url = url;
        }

        private string _ProductName;

        public string ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                OnPropertyChanged("ProductName");
                _ProductName = value;
            }
        }

        private string _Description;
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnPropertyChanged("Description");
                _Description = value;
            }
        }

        private string _Price;
        public string Price
        {
            get
            {
                return _Price + " руб.";
            }
            set
            {
                OnPropertyChanged("Price");
                _Price = value;
            }
        }

        private string _AddedDate;
        public DateTime AddedDate
        {
            get
            {
                return DateTime.Parse(_AddedDate);
            }
            set
            {
                OnPropertyChanged("AddedDate");
                _AddedDate = value.ToShortDateString();
            }
        }
    }

    public class ViewerTable_ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MeProducts> MeProducts { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private MeProducts _SelectProduct;

        public MeProducts SelectProduct
        {
            get
            {
                return _SelectProduct;
            }
            set
            {
                OnPropertyChanged("SelectProduct");
                _SelectProduct = value;
            }
        }


        public ViewerTable_ViewModel(List<MeProducts> meProducts)
        {
            MeProducts = new ObservableCollection<MeProducts>();
            MeProducts.Clear();
            foreach(var v in meProducts)
            {
                MeProducts.Add(v);
            }
        }

        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(propertyName, new PropertyChangedEventArgs(propertyName));
    }
}
