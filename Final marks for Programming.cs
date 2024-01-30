using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_03
{
    public partial class Form1 : Form
    {
        private Student student;
        public Form1()
        {
            InitializeComponent();
            student = new Student();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Next Button (Clear all the fields)
            MajorTest1.Clear();
            MajorTest2.Clear();
            ClassTest1.Clear();
            ClassTest2.Clear();
            ExamMark.Clear();
            MBox.Clear();
        }

        private void FinalMark_Click(object sender, EventArgs e)
        {
            // Calculate final mark
            try
            {

                // Parse input values from text boxes
                student.majorTest1 = double.Parse(MajorTest1.Text);
                student.majorTest2 = double.Parse(MajorTest2.Text);
                student.classTest1 = double.Parse(ClassTest1.Text);
                student.classTest2 = double.Parse(ClassTest2.Text);
                student.examMark = double.Parse(ExamMark.Text);
                double bestClassTestMark = Math.Max(student.classTest1, student.classTest2);
                double finalMark = (student.majorTest1 * 0.15) + (student.majorTest2 * 0.20) + (bestClassTestMark * 0.15) + (student.examMark * 0.50);
                if (finalMark >= 50)
                {
                    student.Result = "Pass";
                }
                else
                {
                    student.Result = "Fail";
                }

                MBox.Font = new Font(label1.Font, FontStyle.Bold);
                MBox.Text = $"The Final Mark of the student is {finalMark:F2}% The result is a {student.Result}";
            }

            catch (FormatException)
            {
                MessageBox.Show("Please enter valid marks.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void MBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
