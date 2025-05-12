using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace ViewerT
{
    /// <summary>
    /// Логика взаимодействия для CardsViewerControl.xaml
    /// </summary>
    public partial class CardsViewerControl : UserControl
    {

        HandlerProduct ACT_ADD;
        HandlerProduct ACT_DEL;
        HandlerProduct ACT_UPDATE_ORDER;

        public CardsViewerControl(List<Card> _list, HandlerProduct aCT_ADD, HandlerProduct aCT_DEL, HandlerProduct aCT_UPDATE_ORDER)
        {
            InitializeComponent();

            this.DataContext = new MeCards(_list);
            ACT_ADD = aCT_ADD;
            ACT_DEL = aCT_DEL;
            ACT_UPDATE_ORDER = aCT_UPDATE_ORDER;
        }

        public CardsViewerControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int quan = int.Parse(ACT_ADD?.Invoke(int.Parse((sender as Button).Tag.ToString()), sender));
            (this.DataContext as MeCards).MeCardsCollection.Where(x => x.IdProduct == int.Parse((sender as Button).Tag.ToString())).FirstOrDefault().Quantity = quan.ToString();
            foreach (var v in ((sender as Button).Parent as StackPanel).Children)
            {
                if (v is TextBlock)
                {
                    (v as TextBlock).Text = $"{quan}";
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int quan = int.Parse(ACT_DEL?.Invoke(int.Parse((sender as Button).Tag.ToString()), sender));
            (this.DataContext as MeCards).MeCardsCollection.Where(x => x.IdProduct == int.Parse((sender as Button).Tag.ToString())).FirstOrDefault().Quantity = quan.ToString();
            foreach(var v in ((sender as Button).Parent as StackPanel).Children)
            {
                if(v is TextBlock)
                {
                    (v as TextBlock).Text = $"{quan}";
                }
            }
        }
    }

    public class Card : INotifyPropertyChanged
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

        private string _Quantity;

        public string Quantity
        {
            get
            {
                return _Quantity + " ед.";
            }
            set
            {
                OnPropertyChanged("Quantity");
                _Quantity = value;
            }
        }

        private string _AddedDate;
        public DateTime AddedDate
        {
            get
            {
                return  DateTime.Parse(_AddedDate);
            }
            set
            {
                OnPropertyChanged("AddedDate");
                _AddedDate = value.ToShortDateString();
            }
        }
    }

    public class MeCards : INotifyPropertyChanged
    {

        public ObservableCollection<Card> MeCardsCollection { get; set; }


        public MeCards(List<Card> _list)
        {
            MeCardsCollection = new ObservableCollection<Card>();
            foreach(var v in _list)
            {
                MeCardsCollection.Add(v);
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(propertyName, new PropertyChangedEventArgs(propertyName));
    }
}
