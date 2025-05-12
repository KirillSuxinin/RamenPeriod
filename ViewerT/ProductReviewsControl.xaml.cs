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
    /// Логика взаимодействия для ProductReviewsControl.xaml
    /// </summary>
    public partial class ProductReviewsControl : UserControl
    {
        public ProductReviewsControl(List<Reviews> list)
        {
            InitializeComponent();
            this.DataContext = new ProductReviews_View(list);
        }

        public ProductReviewsControl()
        {
            InitializeComponent();
        }
    }

    public class Reviews : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        private string _Comment;
        public string Comment
        {
            get
            {
                return _Comment;
            }
            set
            {
                OnPropertyChanged("Comment");
                _Comment = value;
            }
        }

        private string _Rating;
        public string Rating
        {
            get
            {
                return _Rating;
            }
            set
            {
                OnPropertyChanged("Rating");
                _Rating = value;
            }
        }

        private string _ReviewDate;
        public DateTime ReviewDate
        {
            get
            {
                return DateTime.Parse(_ReviewDate);
            }
            set
            {
                OnPropertyChanged("ReviewDate");
                _ReviewDate = value.ToShortDateString();
            }
        }

        private string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                OnPropertyChanged("FirstName");
                _FirstName = value;
            }
        }

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
        private Bitmap _PicStar;
        public BitmapImage PicStar
        {
            get
            {
                BitmapImage bt = new BitmapImage();
                var bitm = _PicStar;
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
                OnPropertyChanged("PicStar");
                
            }
        }

        public void SetPicStar(Bitmap img)
        {
            _PicStar = img;
        }

    }

    public class ProductReviews_View : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(propertyName, new PropertyChangedEventArgs(propertyName));

        public ObservableCollection<Reviews> ProductReviews { get; set; }

        private string image_url;

        public void SetUrlImage(string url)
        {
            this.image_url = url;
        }

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

        public ProductReviews_View(List<Reviews> rev_dat)
        {
            ProductReviews = new ObservableCollection<Reviews>();
            foreach(var el in rev_dat)
            {
                ProductReviews.Add(el);
            }
        }
    }


}
