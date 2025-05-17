using static Lab_5_Horbach_633p.Methods;
using System.Text;

namespace Lab_5_Horbach_633p
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Methods assignmentMatrix = new Methods();

        private void button_result_Click(object sender, EventArgs e)
        {
            // Створюємо об'єкт для роботи з матрицею
            assignmentMatrix.ParseMatrix(textBox_matrix_values.Text);
            assignmentMatrix.CalculateAppointments();
            textBox_matrix_appointments.Text = assignmentMatrix.GetAppointmentsAsString();
            textBox_cost.Text = assignmentMatrix.TotalCost.ToString();
        }

        private void button_protocol_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt",
                FileName = "Protocol.txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                assignmentMatrix.SaveProtocolToFile(saveFileDialog.FileName);
                MessageBox.Show("Протокол збережено успішно!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
