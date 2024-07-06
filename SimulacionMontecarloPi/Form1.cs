using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulacionMontecarloPi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numPoints;
            if (int.TryParse(textBox1.Text, out numPoints) && numPoints > 0)
            {
                double piApprox = ApproximatePi(numPoints);
                label2.Text = $"Aproximación de Pi: {piApprox}";
            }
            else
            {
                MessageBox.Show("Por favor ingrese un número válido de puntos.", "Entrada no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private double ApproximatePi(int numPoints)
        {
            int pointsInsideCircle = 0;
            Random random = new Random();

            for (int i = 0; i < numPoints; i++)
            {
                double x = random.NextDouble() * 2 - 1; // Genera un número aleatorio entre -1 y 1
                double y = random.NextDouble() * 2 - 1; // Genera un número aleatorio entre -1 y 1
                if (x * x + y * y <= 1)
                {
                    pointsInsideCircle += 1;
                }
            }

            return 4.0 * pointsInsideCircle / numPoints;
        }
    }
}
