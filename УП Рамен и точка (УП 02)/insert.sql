--Categories +
INSERT INTO Categories (CategoryID, CategoryName, [Description]) VALUES (1, 'Классический рамен', 'Традиционные японские рецепты рамена.');
INSERT INTO Categories (CategoryID, CategoryName, [Description]) VALUES (2, 'Острый рамен', 'Рамен с добавлением острых специй и соусов.');
INSERT INTO Categories (CategoryID, CategoryName, [Description]) VALUES (3, 'Вегетарианский рамен', 'Рамен без мяса, с использованием овощей и тофу.');
INSERT INTO Categories (CategoryID, CategoryName, [Description]) VALUES (4, 'Напитки', 'Прохладительные и горячие напитки.');
INSERT INTO Categories (CategoryID, CategoryName, [Description]) VALUES (5, 'Дополнительные ингредиенты', 'Дополнительные топпинги к рамену');
INSERT INTO Categories (CategoryID, CategoryName, [Description]) VALUES (6, 'Рамен быстрого приготовления', 'Быстро и вкусно!');
INSERT INTO Categories (CategoryID, CategoryName, [Description]) VALUES (7, 'Детское меню', 'Специально для детей');
INSERT INTO Categories (CategoryID, CategoryName, [Description]) VALUES (8, 'Десерты', 'Сладкое к рамену');
INSERT INTO Categories (CategoryID, CategoryName, [Description]) VALUES (9, 'Сезонные предложения', 'Ограниченные по времени блюда.');
INSERT INTO Categories (CategoryID, CategoryName, [Description]) VALUES (10, 'Комбо-наборы', 'Рамен + напиток + закуска по выгодной цене.');

--Products +
INSERT INTO Products (ProductID, CategoryID, ProductName, [Description], Price) VALUES (1, 1, 'Рамен Тонкоцу', 'Насыщенный свиной бульон, лапша, свинина чашу, яйцо, зеленый лук.', 450.00);
INSERT INTO Products (ProductID, CategoryID, ProductName, [Description], Price) VALUES (2, 2, 'Каракай Рамен', 'Острый куриный бульон, лапша, курица, перец чили, кунжут.', 500.00);
INSERT INTO Products (ProductID, CategoryID, ProductName, [Description], Price) VALUES (3, 3, 'Овощной Рамен', 'Овощной бульон, лапша, тофу, грибы шиитаке, морковь, шпинат.', 400.00);
INSERT INTO Products (ProductID, CategoryID, ProductName, [Description], Price) VALUES (4, 4, 'Coca-Cola', 'Охлажденная Coca-Cola.', 100.00);
INSERT INTO Products (ProductID, CategoryID, ProductName, [Description], Price) VALUES (5, 5, 'Яйцо Аджитама', 'Маринованное яйцо.', 50.00);
INSERT INTO Products (ProductID, CategoryID, ProductName, [Description], Price) VALUES (6, 6, 'Рамен со вкусом курицы', 'Просто добавь воды!', 150.00);
INSERT INTO Products (ProductID, CategoryID, ProductName, [Description], Price) VALUES (7, 1, 'Шио Рамен', 'Бульон на основе морской соли, лапша, курица, нори, зеленый лук.', 420.00);
INSERT INTO Products (ProductID, CategoryID, ProductName, [Description], Price) VALUES (8, 8, 'Моти', 'Традиционный японский десерт из рисового теста.', 200.00);
INSERT INTO Products (ProductID, CategoryID, ProductName, [Description], Price) VALUES (9, 9, 'Рамен с креветками (зимний)', 'Креветочный бульон, лапша, креветки, овощи.', 550.00);
INSERT INTO Products (ProductID, CategoryID, ProductName, [Description], Price) VALUES (10, 10, 'Комбо "Классика"', 'Рамен Тонкоцу, Coca-Cola, Яйцо Аджитама.', 550.00);

--Users +
INSERT INTO Users (UserID, FirstName, LastName, Email, [Password], Phone) VALUES (1, 'Иван', 'Иванов', 'ivan@example.com', 'hashed_[Password]_1', '+79001234567');
INSERT INTO Users (UserID, FirstName, LastName, Email, [Password], Phone) VALUES (2, 'Мария', 'Петрова', 'maria@example.com', 'hashed_[Password]_2', '+79123456789');
INSERT INTO Users (UserID, FirstName, LastName, Email, [Password]) VALUES (3, 'Алексей', 'Сидоров', 'alex@example.com', 'hashed_[Password]_3');
INSERT INTO Users (UserID, FirstName, LastName, Email, [Password], Phone, Address) VALUES (4, 'Елена', 'Смирнова', 'elena@example.com', 'hashed_[Password]_4', '+79234567890', 'ул. Ленина, 10');
INSERT INTO Users (UserID, FirstName, LastName, Email, [Password]) VALUES (5, 'Дмитрий', 'Козлов', 'dmitry@example.com', 'hashed_[Password]_5');
INSERT INTO Users (UserID, FirstName, LastName, Email, [Password], Phone) VALUES (6, 'Ольга', 'Волкова', 'olga@example.com', 'hashed_[Password]_6', '+79345678901');
INSERT INTO Users (UserID, FirstName, LastName, Email, [Password]) VALUES (7, 'Сергей', 'Морозов', 'sergey@example.com', 'hashed_[Password]_7');
INSERT INTO Users (UserID, FirstName, LastName, Email, [Password], Phone, Address) VALUES (8, 'Наталья', 'Лебедева', 'natalia@example.com', 'hashed_[Password]_8', '+79456789012', 'пр. Мира, 25');
INSERT INTO Users (UserID, FirstName, LastName, Email, [Password]) VALUES (9, 'Андрей', 'Павлов', 'andrey@example.com', 'hashed_[Password]_9');
INSERT INTO Users (UserID, FirstName, LastName, Email, [Password], Phone) VALUES (10, 'Юлия', 'Николаева', 'julia@example.com', 'hashed_[Password]_10', '+79567890123');

--addresses +
INSERT INTO Addresses (AddressID, UserID, AddressLine, City, State) VALUES (1, 1, 'ул. Пушкина, 5', 'Москва', 'Московская область');
INSERT INTO Addresses (AddressID, UserID, AddressLine, City) VALUES (2, 1, 'пр. Гагарина, 12', 'Санкт-Петербург');
INSERT INTO Addresses (AddressID, UserID, AddressLine, City) VALUES (3, 2, 'ул. Ленина, 20', 'Екатеринбург');
INSERT INTO Addresses (AddressID, UserID, AddressLine, City, State) VALUES (4, 3, 'ул. Мира, 15', 'Новосибирск', 'Новосибирская область');
INSERT INTO Addresses (AddressID, UserID, AddressLine, City) VALUES (5, 4, 'ул. Строителей, 8', 'Казань');
INSERT INTO Addresses (AddressID, UserID, AddressLine, City, State) VALUES (6, 5, 'ул. Советская, 3', 'Нижний Новгород', 'Нижегородская область');
INSERT INTO Addresses (AddressID, UserID, AddressLine, City) VALUES (7, 6, 'ул. Кирова, 10', 'Челябинск');
INSERT INTO Addresses (AddressID, UserID, AddressLine, City, State) VALUES (8, 7, 'ул. 8 Марта, 7', 'Самара', 'Самарская область');
INSERT INTO Addresses (AddressID, UserID, AddressLine, City) VALUES (9, 8, 'ул. Карла Маркса, 1', 'Омск');
INSERT INTO Addresses (AddressID, UserID, AddressLine, City, State) VALUES (10, 9, 'ул. Первомайская, 12', 'Ростов-на-Дону', 'Ростовская область');

--Orders +
INSERT INTO Orders (OrderID, UserID, AddressID, TotalAmount, OrderStatus, PaymentMethod) VALUES (1, 1, 1, 900.00, 'Доставлен', 'Картой');
INSERT INTO Orders (OrderID, UserID, AddressID, TotalAmount, OrderStatus, PaymentMethod) VALUES (2, 2, 3, 450.00, 'Выполняется', 'Наличные');
INSERT INTO Orders (OrderID, UserID, AddressID, TotalAmount, OrderStatus, PaymentMethod) VALUES (3, 3, 4, 1000.00, 'Сформирован', 'Онлайн');
INSERT INTO Orders (OrderID, UserID, AddressID, TotalAmount, OrderStatus, PaymentMethod) VALUES (4, 4, 5, 600.00, 'Передан в доставку', 'Картой');
INSERT INTO Orders (OrderID, UserID, AddressID, TotalAmount, OrderStatus, PaymentMethod) VALUES (5, 5, 6, 300.00, 'Отменён', 'Наличные');
INSERT INTO Orders (OrderID, UserID, AddressID, TotalAmount, OrderStatus, PaymentMethod) VALUES (6, 6, 7, 750.00, 'Доставлен', 'Онлайн');
INSERT INTO Orders (OrderID, UserID, AddressID, TotalAmount, OrderStatus, PaymentMethod) VALUES (7, 7, 8, 500.00, 'Выполняется', 'Картой');
INSERT INTO Orders (OrderID, UserID, AddressID, TotalAmount, OrderStatus, PaymentMethod) VALUES (8, 8, 9, 1200.00, 'Сформирован', 'Наличные');
INSERT INTO Orders (OrderID, UserID, AddressID, TotalAmount, OrderStatus, PaymentMethod) VALUES (9, 9, 10, 850.00, 'Передан в доставку', 'Онлайн');
INSERT INTO Orders (OrderID, UserID, AddressID, TotalAmount, OrderStatus, PaymentMethod) VALUES (10, 10, 2, 400.00, 'Отменён', 'Картой');

--OrderItem +
INSERT INTO OrderItems (OrderItemID, OrderID, ProductID, Quantity, Price) VALUES (1, 1, 1, 2, 450.00);
INSERT INTO OrderItems (OrderItemID, OrderID, ProductID, Quantity, Price) VALUES (2, 1, 4, 1, 100.00);
INSERT INTO OrderItems (OrderItemID, OrderID, ProductID, Quantity, Price) VALUES (3, 2, 2, 1, 500.00);
INSERT INTO OrderItems (OrderItemID, OrderID, ProductID, Quantity, Price) VALUES (4, 3, 3, 2, 400.00);
INSERT INTO OrderItems (OrderItemID, OrderID, ProductID, Quantity, Price) VALUES (5, 3, 5, 4, 50.00);
INSERT INTO OrderItems (OrderItemID, OrderID, ProductID, Quantity, Price) VALUES (6, 4, 1, 1, 450.00);
INSERT INTO OrderItems (OrderItemID, OrderID, ProductID, Quantity, Price) VALUES (7, 4, 4, 1, 100.00);
INSERT INTO OrderItems (OrderItemID, OrderID, ProductID, Quantity, Price) VALUES (8, 5, 2, 1, 500.00);
INSERT INTO OrderItems (OrderItemID, OrderID, ProductID, Quantity, Price) VALUES (9, 6, 3, 1, 400.00);
INSERT INTO OrderItems (OrderItemID, OrderID, ProductID, Quantity, Price) VALUES (10, 6, 5, 2, 50.00);

--shopcart +
INSERT INTO ShoppingCart (CartID, UserID, ProductID, Quantity) VALUES (1, 1, 1, 1);
INSERT INTO ShoppingCart (CartID, UserID, ProductID, Quantity) VALUES (2, 1, 4, 2);
INSERT INTO ShoppingCart (CartID, UserID, ProductID, Quantity) VALUES (3, 2, 2, 1);
INSERT INTO ShoppingCart (CartID, UserID, ProductID, Quantity) VALUES (4, 3, 3, 3);
INSERT INTO ShoppingCart (CartID, UserID, ProductID, Quantity) VALUES (5, 4, 1, 2);
INSERT INTO ShoppingCart (CartID, UserID, ProductID, Quantity) VALUES (6, 5, 2, 1);
INSERT INTO ShoppingCart (CartID, UserID, ProductID, Quantity) VALUES (7, 6, 3, 1);
INSERT INTO ShoppingCart (CartID, UserID, ProductID, Quantity) VALUES (8, 7, 1, 1);
INSERT INTO ShoppingCart (CartID, UserID, ProductID, Quantity) VALUES (9, 8, 2, 2);
INSERT INTO ShoppingCart (CartID, UserID, ProductID, Quantity) VALUES (10, 9, 3, 1);

--comments +
INSERT INTO ProductReviews (ReviewID, ProductID, UserID, Rating, Comment) VALUES (1, 1, 1, 5, 'Отличный рамен!');
INSERT INTO ProductReviews (ReviewID, ProductID, UserID, Rating, Comment) VALUES (2, 1, 2, 4, 'Вкусно, но немного дорого.');
INSERT INTO ProductReviews (ReviewID, ProductID, UserID, Rating) VALUES (3, 2, 3, 4);
INSERT INTO ProductReviews (ReviewID, ProductID, UserID, Rating, Comment) VALUES (4, 3, 4, 5, 'Очень понравился вегетарианский вариант!');
INSERT INTO ProductReviews (ReviewID, ProductID, UserID, Rating) VALUES (5, 1, 5, 2);
INSERT INTO ProductReviews (ReviewID, ProductID, UserID, Rating, Comment) VALUES (6, 2, 6, 4, 'Острый, как я люблю!');
INSERT INTO ProductReviews (ReviewID, ProductID, UserID, Rating) VALUES (7, 3, 7, 5);
INSERT INTO ProductReviews (ReviewID, ProductID, UserID, Rating, Comment) VALUES (8, 1, 8, 3, 'Неплохо, но можно и лучше.');
INSERT INTO ProductReviews (ReviewID, ProductID, UserID, Rating) VALUES (9, 2, 9, 3);
INSERT INTO ProductReviews (ReviewID, ProductID, UserID, Rating, Comment) VALUES (10, 3, 10, 4, 'Рекомендую!');

--discount +
INSERT INTO Promotions (PromotionID, PromotionName, [Description], DiscountPercentage, ProductID) VALUES (1, 'Скидка на Тонкоцу', 'Скидка 10% на рамен Тонкоцу.', 10.00, 1);
INSERT INTO Promotions (PromotionID, PromotionName, [Description], DiscountPercentage, CategoryID) VALUES (2, 'Счастливые часы', 'Скидка 15% на все напитки с 14:00 до 16:00.', 15.00, 4);
INSERT INTO Promotions (PromotionID, PromotionName, [Description], DiscountPercentage) VALUES (3, 'Комбо по цене рамена', 'При покупке рамена - напиток в подарок.', 100.00);
INSERT INTO Promotions (PromotionID, PromotionName, [Description], DiscountPercentage, ProductID) VALUES (4, 'Рамен месяца', 'Скидка на рамен месяца.', 25.00, 2);
INSERT INTO Promotions (PromotionID, PromotionName, [Description], DiscountPercentage, CategoryID) VALUES (5, 'Вегетарианский вторник', 'Скидка 20% на все вегетарианские блюда по вторникам.', 20.00, 3);
INSERT INTO Promotions (PromotionID, PromotionName, [Description], DiscountPercentage, ProductID) VALUES (6, 'Счастливый обед', 'Скидка 30% с 12:00 до 14:00 на всё меню.', 30.00, 3);
INSERT INTO Promotions (PromotionID, PromotionName, [Description], DiscountPercentage, CategoryID) VALUES (7, 'Ко дню рождения!', 'Скидка 15% в день рождения и 3 дня после.', 15.00, 7);
INSERT INTO Promotions (PromotionID, PromotionName, [Description], DiscountPercentage, ProductID) VALUES (8, 'Попробуй первым!', 'Скидка 15% на новинки.', 15.00, 8);
INSERT INTO Promotions (PromotionID, PromotionName, [Description], DiscountPercentage, CategoryID) VALUES (9, 'Приведи друга - получи скидку!', 'Приведи друга - получи скидку 10% на свой заказ.', 10.00, 9);
INSERT INTO Promotions (PromotionID, PromotionName, [Description], DiscountPercentage, ProductID) VALUES (10, 'Закажи на 2000 - получи десерт в подарок!', 'Закажи на сумму от 2000 - получи десерт в подарок!', 50.00, 9);

--payments +
INSERT INTO PaymentStatus(PaymentStatusID, OrderID, [Status]) VALUES (1, 1, 'Оплачен');
INSERT INTO PaymentStatus(PaymentStatusID, OrderID, [Status]) VALUES (2, 2, 'Ожидает');
INSERT INTO PaymentStatus(PaymentStatusID, OrderID, [Status]) VALUES (3, 3, 'Оплачен');
INSERT INTO PaymentStatus(PaymentStatusID, OrderID, [Status]) VALUES (4, 4, 'Ожидает');
INSERT INTO PaymentStatus(PaymentStatusID, OrderID, [Status]) VALUES (5, 5, 'Отменён');
INSERT INTO PaymentStatus(PaymentStatusID, OrderID, [Status]) VALUES (6, 6, 'Оплачен');
INSERT INTO PaymentStatus(PaymentStatusID, OrderID, [Status]) VALUES (7, 7, 'Ожидает');
INSERT INTO PaymentStatus(PaymentStatusID, OrderID, [Status]) VALUES (8, 8, 'Ожидает');
INSERT INTO PaymentStatus(PaymentStatusID, OrderID, [Status]) VALUES (9, 9, 'Оплачен');
INSERT INTO PaymentStatus(PaymentStatusID, OrderID, [Status]) VALUES (10, 10, 'Отменён');