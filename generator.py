import uuid
from faker import Faker
import mysql.connector

# Konfiguracja połączenia z bazą danych
db_config = {
    'user': 'root',
    'password': '',
    'host': 'localhost',
    'database': 'biblioteka'
}

# Tworzenie obiektu faker
fake = Faker()

# Generowanie danych
records = []
for i in range(200):
    title =  fake.sentence(nb_words=4)
    author = fake.name()
    publish_date = fake.date_between(start_date='-10y', end_date='today')
    description = fake.text(max_nb_chars=200)
    quantity = fake.random_int(min=1, max=20)
    book_uuid = str(uuid.uuid4())
    
    record = (title, author, publish_date, description, quantity, book_uuid)
    records.append(record)

# Połączenie z bazą danych i wstawianie danych
try:
    connection = mysql.connector.connect(**db_config)
    cursor = connection.cursor()
    
    # Tworzenie tabeli jeśli nie istnieje
    create_table_query = """
    CREATE TABLE IF NOT EXISTS katalog_biblioteczny (
        Id_Książki INT PRIMARY KEY AUTO_INCREMENT,
        Tytuł VARCHAR(255) NOT NULL,
        Autor VARCHAR(255) NOT NULL,
        Data_Wydania DATE NOT NULL,
        Opis TEXT,
        ilośćSztuk INT NOT NULL,
        UUID CHAR(36) NOT NULL
    );
    """
    cursor.execute(create_table_query)
    
    # Wstawianie rekordów
    insert_query = """
    INSERT INTO katalog_biblioteczny (Tytuł, Autor, Data_Wydania, Opis, ilośćSztuk, UUID)
    VALUES (%s, %s, %s, %s, %s, %s)
    """
    cursor.executemany(insert_query, records)
    connection.commit()
    print("200 records inserted successfully.")

except mysql.connector.Error as err:
    print(f"Error: {err}")
finally:
    if connection.is_connected():
        cursor.close()
        connection.close()
        print("MySQL connection is closed.")
