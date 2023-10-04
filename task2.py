import findspark
findspark.init()

from pyspark.sql import SparkSession

class Query:

           
    def spark_version(self,products,categories,products_vs_categories): #метод с реализацией spark 
        return products.join(products_vs_categories,products.id == products_vs_categories.product_id,"left")\
                       .join(categories,categories.id == products_vs_categories.category_id,"left")\
                       .select("product_name","category_name").sort("product_name","category_name")    

    def sql_version(self,products,categories,products_vs_categories):  #метод с реализацией sql запроса
        products.createOrReplaceTempView("products")
        categories.createOrReplaceTempView("categories")
        products_vs_categories.createOrReplaceTempView("product_vs_categories")

        return spark.sql("select product_name, category_name from products left join product_vs_categories on products.id = product_vs_categories.product_id left join categories on categories.id = product_vs_categories.category_id order by product_name, category_name")

# тут проверка реализации
spark = SparkSession.builder.getOrCreate()

products = spark.createDataFrame([
    (1, "Пылесос"),
    (2, "Молоко"),
    (3, "Масло"),
    (4, "Корм для животных"),
    (5, "Шампунь"),
    (6, "Яйца"),
    (7, "Телевизор")
], schema = " id int, product_name string ")


categories = spark.createDataFrame([
    (1, "Электроника"),
    (2, "Бытовая техника"),
    (3, "Продукты"),
    (4, "Товары для ухода"),
    (5, "Молочные продукты")
], schema = " id int, category_name string ")


products_vs_categories = spark.createDataFrame([
    (1, 1),
    (1, 2),
    (2, 3),
    (2, 5),
    (3, 3),
    (3, 5),
    (5, 4),
    (6, 3),
    (7, 1),
], schema = "product_id int, category_id int"
)

query = Query()
query.spark_version(products,categories,products_vs_categories).show()
query.sql_version(products,categories,products_vs_categories).show()