using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private bool t_up;
        private bool t_down;
        private bool t_left;
        private bool t_right;
        private bool c_up;
        private bool c_down;
        private bool c_left;
        private bool c_right;
        private double bulletSpeed = 20;
        private double targetSpeed = 8;
        private double cannonSpeed = 3;
        private double p_x;
        private double p_y;
        private double t_x;
        private double t_y;

        //private int projectileInitialPosX;
        //private int projectileInitialPosY;
        private bool projFired = false;
        private double angle = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    t_up = true;
                    break;
                case Keys.Down:
                    t_down = true;
                    break;
                case Keys.Left:
                    t_left = true;
                    break;
                case Keys.Right:
                    t_right = true;
                    break;
            }
            switch (e.KeyCode)
            {
                case Keys.W:
                    c_up = true;
                    break;
                case Keys.S:
                    c_down = true;
                    break;
                case Keys.A:
                    c_left = true;
                    break;
                case Keys.D:
                    c_right = true;
                    break;
            }

            targetTime.Start();

            //Invalidate();
        }
        private void _DoMovement()
        {
            if (t_left) Target.Left -= (int)targetSpeed;
            if (t_right) Target.Left += (int)targetSpeed;
            if (t_up) Target.Top -= (int)targetSpeed;
            if (t_down) Target.Top += (int)targetSpeed;

            if (c_left) Cannon.Left -= (int)cannonSpeed;
            if (c_right) Cannon.Left += (int)cannonSpeed;
            if (c_up) Cannon.Top -= (int)cannonSpeed;
            if (c_down) Cannon.Top += (int)cannonSpeed;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            if (projFired)
            {
                projMove();
            }
            else
            {
                shoot();
            }
            if (Projectile.Bounds.IntersectsWith(Target.Bounds))
            {
                Console.WriteLine("You lost");
                //Application.Exit();
            }
        }

        private void projMove()
        {
            Projectile.Top += (int)(Math.Sin(angle) * bulletSpeed);
            Projectile.Left += (int)(Math.Cos(angle) * bulletSpeed);
            //Target.Top -= targetVelocity;
            //Target.Left -= targetVelocity;
            if (Projectile.Top < -4 || Projectile.Left > 655 || Projectile.
                Left < -4 || Projectile.Top > 685)
            {
                projFired = false;
                Projectile.Top = Cannon.Top + (Cannon.Height / 2);
                Projectile.Left = Cannon.Left + (Cannon.Width / 2);
            }
            Invalidate();
        }

        private void shoot()
        {
            calculateAngle();
            projFired = true;
        }

        private void calculateAngle()
        {
            t_x = Target.Left + (Target.Width / 2);
            t_y = Target.Top + (Target.Height / 2);

            p_x = Projectile.Left + (Projectile.Width / 2);
            p_y = Projectile.Top + (Projectile.Height / 2);
            double deltaX = t_x - p_x;
            double deltaY = t_y - p_y;
            double alpha0 = Math.Atan2(deltaY , deltaX);

            if (!(t_down || t_left || t_right || t_up) || (t_left && t_right && !t_up && !t_down) || (!t_left && !t_right && t_up && t_down)||(t_left && t_right && t_up && t_down))
            //if (false)
            {
                this.angle = alpha0;
            }
            else
            {
                //double aux = (getTargetSpeed()/ bulletSpeed) * Math.Sin(alpha0 + getTargetDirection());
                this.angle = Math.Asin(getTargetSpeed() / bulletSpeed) * Math.Sin(alpha0 + getTargetDirection()) + alpha0;
                //Console.WriteLine("the auxiliary" + aux);
            }
            Console.WriteLine(this.angle);
            //this.angle += 0.3;

        }

        private double getTargetDirection()
        {
            double targetAngle = 0;
            if ((t_left && !t_right && !t_up && !t_down)||(t_left && !t_right && t_up && t_down)) targetAngle = 0;
            else if ((!t_left && !t_right && !t_up && t_down)||(t_left && t_right && !t_up && t_down)) targetAngle = Math.PI / 2;
            else if ((!t_left && t_right && !t_up && !t_down)||(!t_left && t_right && t_up && t_down)) targetAngle = Math.PI;
            else if ((!t_left && !t_right && t_up && !t_down)||(t_left && t_right && t_up && !t_down)) targetAngle = 3 * Math.PI / 2;
            else if (t_left && !t_right && !t_up && t_down) targetAngle = Math.PI / 4;
            else if (!t_left && t_right && !t_up && t_down) targetAngle = 3 * Math.PI / 4;
            else if (!t_left && t_right && t_up && !t_down) targetAngle = 5 *Math.PI /4;
            else if (t_left && !t_right && t_up && !t_down) targetAngle = 7*Math.PI /4;

            return targetAngle;
        }

        private double getTargetSpeed()
        {
            return (onlyOne(t_up, t_down, t_left, t_right) ? targetSpeed : targetSpeed * Math.Sqrt(2));
        }
        private bool onlyOne(bool a, bool b, bool c, bool d)
        {
            return (a && !b && !c && !d) || (!a && b && !c && !d)|| (!a && !b && c && !d)|| (!a && !b && !c && d);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            _DoMovement();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Up:
                    t_up = false;
                    break;
                case Keys.Down:
                    t_down = false;
                    break;
                case Keys.Left:
                    t_left = false;
                    break;
                case Keys.Right:
                    t_right = false;
                    break;
            }
            switch (e.KeyCode)
            {
                case Keys.W:
                    c_up = false;
                    break;
                case Keys.S:
                    c_down = false;
                    break;
                case Keys.A:
                    c_left = false;
                    break;
                case Keys.D:
                    c_right = false;
                    break;
            }
            if (!(t_down || t_left || t_right || t_up) && !(c_down || c_left || c_right || c_up))
            {
                targetTime.Stop();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Black, (float)t_x - 1, (float)t_y - 1, 1, 1);
        }
    }
}
