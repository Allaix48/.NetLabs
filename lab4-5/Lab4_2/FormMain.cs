﻿using System;
using System.Windows.Forms;
using ClassLibraryRentService;

namespace Lab4_2
{
    public partial class FormMain : Form
    {

        private readonly RentService _RentService = RentService.Instance;
        readonly FormCar _formCar = new FormCar();
        readonly FormClient _formClient = new FormClient();
        readonly FormRentedCar _formRentedCar = new FormRentedCar();

        public FormMain()
        {
            InitializeComponent();
            _RentService.ClientAdded+= _rentService_ClientAdded;
            _RentService.CarAdded += _rentService_CarAdded;
            _RentService.RentedCarAdded+= _rentService_RentedCarAdded;
            _RentService.ClientRemoved += _rentService_ClientRemoved;     
            _RentService.CarRemoved+= _rentService_CarRemoved;
            _RentService.RentedCarRemoved+= _rentService_RentedCarRemoved;
        }


        private void _rentService_RentedCarRemoved(object sender, EventArgs e)
        {
            var RentedCar = sender as RentedCar;
            for (int i = 0; i < listViewRentedCar.Items.Count; i++)
            {
                if ((RentedCar)listViewRentedCar.Items[i].Tag == RentedCar)
                {
                    listViewRentedCar.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void _rentService_CarRemoved(object sender, EventArgs e)
        {
            var CarNumber = (int)sender;
            for (int i = 0; i < listViewCars.Items.Count; i++)
            {
                if (((Car)listViewCars.Items[i].Tag).Number == CarNumber)
                {
                    listViewCars.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void _rentService_ClientRemoved(object sender, EventArgs e)
        {
            var clientId = (int)sender;
            for (int i = 0; i < listViewClients.Items.Count; i++)
            {
                if (((Client)listViewClients.Items[i].Tag).ClientId == clientId)
                {
                    listViewClients.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void _rentService_RentedCarAdded(object sender, EventArgs e)
        {
            var RentedCar = sender as RentedCar;
            if (RentedCar != null)
            {
                var listViewItem = new ListViewItem
                {
                    Tag = RentedCar,
                    Text = RentedCar.Client.ToString()
                };
                listViewItem.SubItems.Add(RentedCar.Car.ToString());
                listViewItem.SubItems.Add(RentedCar.StartDate.ToShortDateString());
                listViewItem.SubItems.Add(RentedCar.EndDate.ToShortDateString());
                listViewRentedCar.Items.Add(listViewItem);
            }
        }

        private void _rentService_CarAdded(object sender, EventArgs e)
        {
            var Car = sender as Car;
            if (Car != null)
            {
                var listViewItem = new ListViewItem
                {
                    Tag = Car,
                    Text = Car.ToString()
                };
                listViewCars.Items.Add(listViewItem);
            }
        }

        private void _rentService_ClientAdded(object sender, EventArgs e)
        {
            var client = sender as Client;
            if (client != null)
            {
                var listViewItem = new ListViewItem
                {
                    Tag = client,
                    Text = client.ToString()
                };
                listViewClients.Items.Add(listViewItem);
            }
        }

        private void addClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var client = new Client();
            _formClient.Client = client;
            if (_formClient.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _RentService.AddClient(client);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }            
        }

        private void editClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var client = listViewClients.SelectedItems[0].Tag as Client;
                _formClient.Client = client;
                if (_formClient.ShowDialog() == DialogResult.OK)
                {
                    listViewClients.SelectedItems[0].Text = _formClient.Client.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана строка с клиентом");
            }
        }


        private void addCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var car = new Car();
            _formCar.Car = car;
            if (_formCar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _RentService.AddCar(car);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

        }

        private void editCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var Car = listViewCars.SelectedItems[0].Tag as Car;
                _formCar.Car = Car;
                if (_formCar.ShowDialog() == DialogResult.OK)
                {
                    listViewCars.SelectedItems[0].Text = _formCar.Car.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана строка с номером");
            }
        }
       
        private void addRentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var RentedCar = new RentedCar();
            _formRentedCar.RentedCar = RentedCar;
            if (_formRentedCar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _RentService.AddRentedCar(RentedCar);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void editRentedCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var RentedCar = listViewRentedCar.SelectedItems[0].Tag as RentedCar;
                _formRentedCar.RentedCar = RentedCar;
                if (_formRentedCar.ShowDialog() == DialogResult.OK)
                {
                    RentedCar = _formRentedCar.RentedCar;
                    var listViewItem = listViewRentedCar.SelectedItems[0];
                    listViewItem.Text = RentedCar.Client.ToString();
                    listViewItem.SubItems[1].Text = RentedCar.Car.ToString();
                    listViewItem.SubItems[2].Text = RentedCar.StartDate.ToShortDateString();
                    listViewItem.SubItems[3].Text = RentedCar.EndDate.ToShortDateString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана строка с поселением");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listViewClients_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    var client = listViewClients.SelectedItems[0].Tag as Client;
                    if (client != null)
                    {
                        _RentService.RemoveClient(client.ClientId);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Не выбрана строка с клиентом");
                }
            }
        }

        private void listViewCars_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    var car = listViewCars.SelectedItems[0].Tag as Car;
                    if (car != null)
                    {
                        _RentService.RemoveCar(car.Number);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Не выбрана строка с номером");
                }
            }
        }

        private void listViewRentedCars_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    var settlement = listViewRentedCar.SelectedItems[0].Tag as RentedCar;
                    if (settlement != null)
                    {
                        _RentService.RemoveRentedCar(settlement);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Не выбрана строка с поселением");
                }
            }
        }


    }
}
