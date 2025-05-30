# Lab_5_Horbach_633p

**на тему:	«РОЗВ’ЯЗАННЯ ЗАДАЧІ ПРО ПРИЗНАЧЕННЯ»**

# Постановка задачі

Під час виконання практичної роботи необхідно:
1.	Розробити програму, яка за допомогою угорського методу за заданою матрицею вартостей робіт буде призначати співробітників на конкретні види робіт.
2.	Дати постановку задачі про призначення як задачі лінійного програмування.
3.	Побудувати симплекс-таблицю для задачі про призначення.
4.	Розв’язати задачу про призначення симплекс-методом (підставити симплекс-таблицю в практичну роботу No 3).

# ВИКОНАННЯ ЗАВДАНЬ ДЛЯ 5 ВАРІАНТУ

![image](https://github.com/user-attachments/assets/a08ade31-14a6-4c31-9567-a2aa7d5fabe4)

**Вхідні та вихідні данні:**

Вхідні данні:

textbox_matrix – матриця вартостей (Matrix) — квадратна матриця розміром n×n, де кожен елемент — це ціле число, що відображає вартість призначення робітника i на роботу j.

Вихідні дані:
textBox_matrix_appointments – вадратна матриця розміром n×n, де 1 означає, що робітник i призначений на роботу j, 0 — відсутність призначення.
textBox_cost – сума вартостей призначень згідно з початковою матрицею.

**Опис основних функцій:**

ParseMatrix(string input) – парсить вхідний рядок input, який містить матрицю у CSV-форматі, формує квадратну матрицю Matrix типу int[,], викидає помилку, якщо формат не відповідає.
CalculateAppointments() – основний метод, що розв’язує задачу призначення за допомогою Угорського алгоритму.
GetAppointmentsAsString() – формує текстове представлення матриці призначень для відображення у формі.
SaveProtocolToFile(string path) – зберігає протокол обчислень у текстовий файл у кодуванні UTF-8.

# Виконання програми:

![image](https://github.com/user-attachments/assets/48c1f4b3-5cce-45de-8b97-6aeaea0b4b3e)
Рисунок 1 – Результат виконання програми

![image](https://github.com/user-attachments/assets/e91938df-b9dd-4529-99f9-94dbe1724ce1)
Рисунок 2 – Протокол обчислення

