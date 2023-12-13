INSERT INTO
    "languages" ("language_code", "language_name", "activation")
VALUES
    ('en', 'English', 1),
    ('ar', 'Arabic', 1);



INSERT INTO
    "categories" ("name", "is_parent", "parent", "activation")
VALUES
    ('MEN', '1', NULL, 1), ('WOMEN', '1', NULL, 1);

INSERT INTO
    "categories_details" (
        "description",
        "translated_name",
        "name",
        "language_code"
    )
VALUES
    ('الوصف رجالي', 'رجالي', 'MEN', 'ar'),
    ('desc Men', 'Men', 'MEN', 'en') ,
    ('نسائي الوصف', 'نسائي', 'WOMEN', 'ar'),
    ('desc Women', 'Women', 'WOMEN', 'en');
INSERT INTO
    "products" (
        "sku",
        "supplier_identity",
        "available_stock",
        "cost_price",
        "discount",
        "is_discounted",
        "reserved_stock",
        "selling_price",
        "total_stock",
        "category",
         "activation"
    )
VALUES
    ('1', 1, 1500, 80, 2, '1', 0, 130, 1500, 'MEN', 1),
    ('2', 1, 1300, 90, 12, '1', 0, 140, 1500, 'WOMEN', 1);

INSERT INTO
    "product_details" ("description", "name", "sku", "language_code")
VALUES
    ('الوصف 1', 'الاسم 1', '1', 'ar'),
    ('desc 1', 'name 1', '1', 'en'),
    ('الوصف 2', 'الاسم 2', '2', 'ar'),
    ('desc 2', 'name 2', '2', 'en');

INSERT INTO
    "categories" ("name", "is_parent", "parent", "activation")
VALUES
    ('MEN', '1', NULL, 1), ('WOMEN', '1', NULL, 1);

INSERT INTO
    "categories_details" (
        "description",
        "translated_name",
        "name",
        "language_code"
    )
VALUES
    ('الوصف رجالي', 'رجالي', 'MEN', 'ar'),
    ('desc Men', 'Men', 'MEN', 'en') ,
    ('نسائي الوصف', 'نسائي', 'WOMEN', 'ar'),
    ('desc Women', 'Women', 'WOMEN', 'en');

--SQL SERVER
INSERT INTO
    "languages" ("language_code", "language_name")
VALUES
    ('en', 'English'),
    ('ar', 'Arabic');

INSERT INTO
    "products" (
        "sku",
        "supplier_identity",
        "available_stock",
        "cost_price",
        "discount",
        "is_discounted",
        "reserved_stock",
        "selling_price",
        "total_stock",
        "category"
    )
VALUES
    ('1', 1, 1500, 80, 2, '1', 0, 130, 1500, NULL),
    ('2', 1, 1300, 90, 12, '1', 0, 140, 1500, NULL);

INSERT INTO
    "product_details" ("description", "name", "sku", "language_code")
VALUES
    (N'الوصف 1', N'الاسم 1', '1', 'ar'),
    ('desc 1', 'name 1', '1', 'en'),
    (N'الوصف 2', N'الاسم 2', '2', 'ar'),
    ('desc 2', 'name 2', '2', 'en');

INSERT INTO
    "categories" ("name", "is_parent", "parent")
VALUES
    ('MEN', '1', NULL) ,('WOMEN', '1', NULL);

INSERT INTO
    "categories_details" (
        "description",
        "translated_name",
        "name",
        "language_code"
    )
VALUES
    (N'الوصف رجالي', N'رجالي', 'MEN', 'ar'),
    ('desc Men', 'Men', 'MEN', 'en'),
    (N'نسائي الوصف', N'نسائي', 'WOMEN', 'ar'),
    ('desc Women', 'Women', 'WOMEN', 'en');