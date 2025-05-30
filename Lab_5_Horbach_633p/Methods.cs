using System;
using System.IO;
using System.Text;

namespace Lab_5_Horbach_633p
{
    public class Methods
    {
        // Матриця вартостей задачі
        public int[,] Matrix { get; set; }
        // Матриця призначень (0/1)
        public int[,] Appointments { get; set; }
        // Загальна вартість призначень
        public int TotalCost { get; set; }
        // Протокол обчислень у вигляді тексту
        private StringBuilder protocol = new StringBuilder();

        // Метод для парсингу вхідних даних (рядок у форматі CSV) у матрицю вартостей
        public void ParseMatrix(string input)
        {
            var rows = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int n = rows.Length;
            Matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                var values = rows[i].Split(',');
                for (int j = 0; j < n; j++)
                {
                    Matrix[i, j] = int.Parse(values[j].Trim());
                }
            }
        }

        // Основний метод для розв’язання задачі про призначення
        public void CalculateAppointments()
        {
            int n = Matrix.GetLength(0);
            // Копіюємо матрицю вартостей, щоб не змінювати оригінал
            int[,] cost = (int[,])Matrix.Clone();
            protocol.Clear();
            protocol.AppendLine("Згенерований протокол обчислення:");
            protocol.AppendLine("Матриця вартостей:");
            AppendMatrix(cost);

            // Крок 1: Віднімання мінімального елемента кожного рядка
            for (int i = 0; i < n; i++)
            {
                int min = cost[i, 0];
                for (int j = 1; j < n; j++)
                    if (cost[i, j] < min) min = cost[i, j]; // Знаходимо мінімальний елемент рядка

                protocol.AppendLine($"В рядку {i + 1} знайдено мінімальний елемент: {min}");

                for (int j = 0; j < n; j++)
                    cost[i, j] -= min; // Віднімаємо мінімальний елемент від кожного елемента рядка
            }

            protocol.AppendLine("Матриця вартостей після віднімання мінімальних елементів у рядках:");
            AppendMatrix(cost);

            // Крок 2: Віднімання мінімального елемента кожного стовпця
            for (int j = 0; j < n; j++)
            {
                int min = cost[0, j];
                for (int i = 1; i < n; i++)
                    if (cost[i, j] < min) min = cost[i, j]; // Знаходимо мінімальний елемент стовпця

                protocol.AppendLine($"В стовпці {j + 1} знайдено мінімальний елемент: {min}");

                for (int i = 0; i < n; i++)
                    cost[i, j] -= min; // Віднімаємо мінімальний елемент від кожного елемента стовпця
            }

            protocol.AppendLine("Матриця вартостей після віднімання мінімальних елементів у стовпцях:");
            AppendMatrix(cost);

            // Починаємо застосовувати угорський алгоритм для пошуку оптимального призначення
            // u і v — потенціали для рядків і стовпців відповідно
            // p — масив відповідностей, way — допоміжний масив для побудови шляху
            int[] u = new int[n + 1], v = new int[n + 1], p = new int[n + 1], way = new int[n + 1];

            for (int i = 1; i <= n; ++i)
            {
                p[0] = i;
                int j0 = 0;
                int[] minv = new int[n + 1];
                bool[] used = new bool[n + 1];
                Array.Fill(minv, int.MaxValue);

                do
                {
                    used[j0] = true;
                    int i0 = p[j0], delta = int.MaxValue, j1 = 0;

                    // Перебір усіх стовпців для пошуку найкращого кандидата
                    for (int j = 1; j <= n; ++j)
                    {
                        if (!used[j])
                        {
                            // Вартість з урахуванням потенціалів
                            int cur = cost[i0 - 1, j - 1] - u[i0] - v[j];
                            if (cur < minv[j])
                            {
                                minv[j] = cur;
                                way[j] = j0; // Запам'ятовуємо шлях
                            }
                            if (minv[j] < delta)
                            {
                                delta = minv[j];
                                j1 = j;
                            }
                        }
                    }

                    // Оновлення потенціалів і мінімальних значень
                    for (int j = 0; j <= n; ++j)
                    {
                        if (used[j])
                        {
                            u[p[j]] += delta;
                            v[j] -= delta;
                        }
                        else
                        {
                            minv[j] -= delta;
                        }
                    }
                    j0 = j1;
                }
                while (p[j0] != 0);

                // Відновлення шляху призначень
                do
                {
                    int j1 = way[j0];
                    p[j0] = p[j1];
                    j0 = j1;
                }
                while (j0 != 0);
            }

            // Ініціалізація матриці призначень нулями
            Appointments = new int[n, n];
            TotalCost = 0;

            protocol.AppendLine("Матриця призначень:");
            // Формуємо матрицю призначень за отриманими індексами
            for (int j = 1; j <= n; ++j)
            {
                int i = p[j] - 1;
                Appointments[i, j - 1] = 1; // Призначення робітнику i роботу j
                TotalCost += Matrix[i, j - 1]; // Додаємо вартість цього призначення до загальної вартості
            }

            AppendMatrix(Appointments);
            protocol.AppendLine($"Загальна вартість робіт:\nS = {TotalCost}");
        }


        // Метод для отримання матриці призначень у вигляді рядка (для виводу)
        public string GetAppointmentsAsString()
        {
            StringBuilder sb = new StringBuilder();
            int n = Appointments.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    sb.Append(Appointments[i, j] + "\t");
                sb.AppendLine();
            }
            return sb.ToString();
        }

        // Збереження протоколу обчислень у файл
        public void SaveProtocolToFile(string path)
        {
            File.WriteAllText(path, protocol.ToString(), Encoding.UTF8);
        }

        // Допоміжний метод для додавання матриці у протокол
        private void AppendMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    protocol.Append(matrix[i, j] + " ");
                protocol.AppendLine();
            }
        }
    }
}
