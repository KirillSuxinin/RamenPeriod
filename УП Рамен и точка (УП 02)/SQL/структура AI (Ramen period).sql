--Пояснения:

--•  Categories: Категории рамена, например, "классический", "острый", "вегетарианский".
--•  Products: Сами блюда рамен, их описание, цена, картинка и остаток на складе.
--•  Additives: Различные добавки к рамену (яйца, мясо, овощи, соусы и т.д.).
--•  ProductAdditives: Связывает рамен с доступными добавками. Удобно, чтобы можно было выбирать опции при заказе.
--•  [Users]: Информация о зарегистрированных пользователях.
--•  Addresses: Адреса доставки пользователей (у одного пользователя может быть несколько адресов).
--•  Orders: Информация о заказах (дата, пользователь, адрес, общая сумма, статус).
--•  OrderItems: Содержимое заказа (какие блюда и в каком количестве были заказаны).
--•  ShoppingCart: Временное хранилище для товаров в корзине перед оформлением заказа.
--•  ProductReviews: Отзывы пользователей о рамене.
--•  Promotions: Информация об акциях и скидках. Может быть привязана к конкретным товарам или категориям.
--•  PaymentMethods: Перечень доступных способов оплаты.

---			Ramen_Period




-- Таблица: Категории товаров (рамен, добавки, напитки и т.д.)
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY NOT NULL,
    CategoryName VARCHAR(MAX) NOT NULL,
    Description VARCHAR(MAX),
    ImageURL VARCHAR(MAX) DEFAULT 'https://sun9-10.userapi.com/impg/IOxWhTf5vHdaErwvUHz6LpVBtdbQXH_eUBHG-w/JrxHi27cfr8.jpg?size=320x320&quality=95&sign=cbbcb855a0aa5040958e0957f92f477b&type=album'
);

-- Таблица: Товары (рамиен, его состав, цена, описание)
CREATE TABLE Products (
    ProductID INT PRIMARY KEY NOT NULL,
    CategoryID INT NOT NULL,
    ProductName VARCHAR(MAX) NOT NULL,
    Description VARCHAR(MAX),
    Price DECIMAL(10, 2) NOT NULL,
	AddedDate DATETIME DEFAULT CURRENT_TIMESTAMP, --Дата добавление продукта в меню (по этому свойству будем делать поиск по новинкам)
    ImageURL VARCHAR(MAX) DEFAULT 'https://sun9-10.userapi.com/impg/IOxWhTf5vHdaErwvUHz6LpVBtdbQXH_eUBHG-w/JrxHi27cfr8.jpg?size=320x320&quality=95&sign=cbbcb855a0aa5040958e0957f92f477b&type=album', -- Путь к изображению товара
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

-- Таблица: Пользователи (покупатели)
CREATE TABLE [Users] (
    UserID INT PRIMARY KEY NOT NULL,
    FirstName VARCHAR(MAX) NOT NULL,
    LastName VARCHAR(MAX) NOT NULL,
    Email VARCHAR(MAX) NOT NULL,
    [Password] VARCHAR(255) NOT NULL,
    Phone VARCHAR(20),
    Address VARCHAR(MAX),
    RegistrationDate DATETIME DEFAULT CURRENT_TIMESTAMP,
	IsAdmin BIT NOT NULL DEFAULT 0
);

-- Таблица: Адреса доставки (для каждого пользователя может быть несколько адресов)
CREATE TABLE Addresses (
    AddressID INT PRIMARY KEY NOT NULL,
    UserID INT NOT NULL,
    AddressLine VARCHAR(MAX) NOT NULL, --УЛИЦА
    City VARCHAR(MAX) NOT NULL, --Город
    [State] VARCHAR(MAX), --Область
    FOREIGN KEY (UserID) REFERENCES [Users](UserID)
);

-- Таблица: Заказы
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY NOT NULL,
    UserID INT NOT NULL,
    AddressID INT,
    OrderDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    OrderStatus VARCHAR(MAX) NOT NULL DEFAULT 'Сформирован' CHECK(OrderStatus = 'Сформирован' OR OrderStatus = 'Выполняется' OR OrderStatus = 'Отменён' OR OrderStatus = 'Передан в доставку' OR OrderStatus = 'Доставлен' ),
    PaymentMethod VARCHAR(MAX) NOT NULL DEFAULT 'Наличные' CHECK(PaymentMethod = 'Наличные' OR PaymentMethod = 'Картой' OR PaymentMethod = 'Онлайн'),
    FOREIGN KEY (UserID) REFERENCES [Users](UserID),
    FOREIGN KEY (AddressID) REFERENCES Addresses(AddressID)
);

-- Таблица: Позиции заказа (какие товары в каком количестве входят в заказ)
CREATE TABLE OrderItems (
    OrderItemID INT PRIMARY KEY NOT NULL,
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL, -- Цена товара на момент заказа
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Таблица: Корзина покупок (временное хранение товаров перед оформлением заказа)
CREATE TABLE ShoppingCart (
    CartID INT PRIMARY KEY NOT NULL,
    UserID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    AddedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UserID) REFERENCES [Users](UserID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Таблица: Отзывы о товарах
CREATE TABLE ProductReviews (
    ReviewID INT PRIMARY KEY NOT NULL,
    ProductID INT NOT NULL,
    UserID INT NOT NULL,
    Rating INT NOT NULL CHECK (Rating >= 1 AND Rating <= 5), -- Оценка от 1 до 5
    [Comment] VARCHAR(MAX),
    ReviewDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (UserID) REFERENCES [Users](UserID)
);

-- Таблица: Акции и скидки
CREATE TABLE Promotions (
    PromotionID INT PRIMARY KEY NOT NULL,
    PromotionName VARCHAR(MAX) NOT NULL,
    Description VARCHAR(MAX),
    DiscountPercentage DECIMAL(5, 2) NOT NULL,
    StartDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    EndDate DATETIME DEFAULT CURRENT_TIMESTAMP + 7, --По умолчанию акция на 7 дней
    IsActive BIT DEFAULT 1,
    ProductID INT, -- Ссылка на конкретный товар (если акция только на него)
    CategoryID INT, -- Ссылка на категорию (если акция на категорию)
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);
--Таблица: Статус платежей
CREATE TABLE PaymentStatus(
	PaymentStatusID INT NOT NULL,
	OrderID INT NOT NULL,
	PaymentDate DATETIME DEFAULT CURRENT_TIMESTAMP,
	[Status] VARCHAR(16) NOT NULL DEFAULT 'Ожидает' CHECK([Status] = 'Ожидает' OR [Status] = 'Отменён' OR [Status] = 'Оплачен'),
	FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
)
