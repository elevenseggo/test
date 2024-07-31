using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool tl1 = false;
        public bool tl2 = false;
        public bool tl3 = false;
        public bool tl4 = false;
        public Panel panel0 = new Panel();
        public Panel panel1 = new Panel();
        public Panel panel2 = new Panel();
        public Panel panel3 = new Panel();

        public Panel man0 = new Panel();
        public Panel man1 = new Panel();
        public Panel man2 = new Panel();
        public Panel man3 = new Panel();


        List<Cars> car = new List<Cars>
        {

        };
        List<People> ppl = new List<People>
        {

        };
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        class Cars
        {
            public int street; //1 - лево; 2 - верх; 3 - право; 4 - низ;
            public int direction; //1 - прямо, 2 - направо. Машины имеют поворотники, а на светофорах установлены камеры, что значит, что светофоры
                                  //знают, куда едут машины
        }

        class People
        {
            public int street, direction; //1, 2
        }
        void Newcars() //создание машин на улицах
        {
            Random rnd = new Random();
            car.Add(new Cars() {street = rnd.Next(4) + 1, direction = rnd.Next(2) + 1 });
            if (car.Any())
            { 
                if (car.Last().street == 1)
                {
                    panel0.Size = new Size(72, 35);
                    panel0.BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                    panel0.Location = new Point(81, 337);
                    Controls.Add(panel0);

                }
                if (car.Last().street == 2)
                {
                    panel1.Size = new Size(35, 72);
                    panel1.BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                    panel1.Location = new Point(349, 496);
                    Controls.Add(panel1);
                }
                if (car.Last().street == 3)
                {
                    panel2.Size = new Size(72, 35);
                    panel2.BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                    panel2.Location = new Point(490, 271);
                    Controls.Add(panel2);
                }
                if (car.Last().street == 4)
                {
                    panel3.Size = new Size(35, 72);
                    panel3.BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                    panel3.Location = new Point(276, 80);
                    Controls.Add(panel3);

                }
            }
            else 
            { return; }
            
        }
        void Newpeople()
        {
            Random rnd1 = new Random();
            ppl.Add(new People() { street = rnd1.Next(4) + 1, direction = rnd1.Next(2) + 1 });

            if (ppl.Any())
            {
                if (ppl.Last().street == 1)
                {
                   man0.Size = new Size(25, 25);
                   man0.BackColor = Color.FromArgb(rnd1.Next(255), rnd1.Next(255), rnd1.Next(255));
                    man0.Location = new Point(188, 211); Controls.Add(man0);
                    
                    
                }
                if (ppl.Last().street == 2)
                {
                     man1.Size = new Size(25, 25);
                    man1.BackColor = Color.FromArgb(rnd1.Next(255), rnd1.Next(255), rnd1.Next(255));
                    man1.Location = new Point(411, 428); Controls.Add(man1);
                   
                    
                }
                if (ppl.Last().street == 3)
                {
                    man2.Size = new Size(25, 25);
                    man2.BackColor = Color.FromArgb(rnd1.Next(255), rnd1.Next(255), rnd1.Next(255));
                    man2.Location = new Point(431, 196); Controls.Add(man2); 
                    

                }
                if (ppl.Last().street == 4)
                {
                    man3.Size = new Size(25, 25);
                    man3.BackColor = Color.FromArgb(rnd1.Next(255), rnd1.Next(255), rnd1.Next(255));
                    man3.Location = new Point(415, 188); Controls.Add(man3);
                    

                }
                else { return; }
                
            }
        }
       async private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                Newcars();
                await Task.Delay(15000);
            }
        }
        async private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
            Newpeople();
                await Task.Delay(15000);
            }
        }

        class trafficlight
        {
            public int id, status; //1 - зеленый, 2 - желтый, 3 - красный
            public string type;

        }


        async private void changelight()
        {
            List<trafficlight> autos = new List<trafficlight>
             {
                  new trafficlight{id = 1, status = 3, type = "forcars"},
                  new trafficlight{id = 2, status = 3, type = "forcars"},
                  new trafficlight{id = 3, status = 3, type = "forcars"},
                  new trafficlight{id = 4, status = 3, type = "forcars"},
              };
            List<trafficlight> passengers = new List<trafficlight>
             {
                  new trafficlight{id = 5, status = 2, type = "passeng"}, //противоположные друг
                  new trafficlight{id = 6, status = 2, type = "passeng"}, //другу светофоры для пешеходов идентичны
                  new trafficlight{id = 7, status = 2, type = "passeng"}, //поэтому для них существует лишь 4 id
                  new trafficlight{id = 8, status = 2, type = "passeng"},
              };
            for (int index = 0; index < autos.Count; index++)
            {
                switch (autos[index].status)
                {
                    case 1:
                        Controls["tf" + index].BackColor = Color.Green;
                        break;
                    case 2:
                        Controls["tf" + index].BackColor = Color.Yellow;
                        break;
                    case 3:
                        Controls["tf" + index].BackColor = Color.Red;
                        break;

                }
            }

            for (int index = 0; index < passengers.Count; index++)
            {
                switch (passengers[index].status)
                {
                    case 1:
                        Controls["peopletl" + index].BackColor = Color.Green;
                        Controls["peopletl" + index + "_"].BackColor = Color.Green;
                        break;
                    case 2:
                        Controls["peopletl" + index].BackColor = Color.Red;
                        Controls["peopletl" + index + "_"].BackColor = Color.Red;
                        break;
                }
            }
            //РАБОТА CВЕТОФОРОВ
            var item = ppl.Find(x => x.street == 1);
            var item2 = ppl.Find(x => x.street == 2);
            var item3 = ppl.Find(x => x.street == 3);
            var item4 = ppl.Find(x => x.street == 4);
            if (car.Any())
            {
                switch (car.Last().street)
                {
                    case 1: //улица 1, светофор 1
                        if (ppl.Any()) //есть ли люди на всех улицах
                        {
                            if (item != null) //есть ли люди на 1-ой улице
                            {
                                PASSred2green(0);
                                await Task.Delay(2000);
                                man0.Location = new Point(188, 280);
                                await Task.Delay(500);
                                man0.Location = new Point(188, 344);
                                await Task.Delay(500);
                                man0.Location = new Point(188, 400);
                                await Task.Delay(500);
                                ppl.Remove(ppl.Last());
                                Controls.Remove(man0);
                                PASSgreen2red(0);
                            }
                            if (item2 != null) //есть ли люди на 2 улице
                            {
                                switch (car.Last().direction)
                                {
                                    case 1: //ПРЯМО
                                        switch (autos[1].status)
                                        {
                                            case 1: case 2: await Task.Delay(500); break;
                                            case 3:
                                                if (autos[3].status == 3)
                                                {
                                                    AUTOyellow2green(0);
                                                    await Task.Delay(500);
                                                    panel0.Location = new Point(286, 337);
                                                    await Task.Delay(500);
                                                    panel0.Location = new Point(483, 337);
                                                    await Task.Delay(500);
                                                    panel0.Location = new Point(627, 337);
                                                    await Task.Delay(500);
                                                    car.Remove(car.Last());
                                                    Controls.Remove(panel0);
                                                    AUTOyellow2red(0);

                                                    PASSred2green(2);
                                                    await Task.Delay(2000);
                                                    man2.Location = new Point(431, 250);
                                                    await Task.Delay(500);
                                                    man2.Location = new Point(431, 350);
                                                    await Task.Delay(500);
                                                    man2.Location = new Point(431, 450);
                                                    await Task.Delay(500);
                                                    ppl.Remove(ppl.Last());
                                                    Controls.Remove(man2);
                                                    PASSgreen2red(2);
                                                    await Task.Delay(500);
                                                }
                                                else
                                                {
                                                    PASSred2green(2);
                                                    await Task.Delay(2000);
                                                    man2.Location = new Point(431, 250);
                                                    await Task.Delay(500);
                                                    man2.Location = new Point(431, 350);
                                                    await Task.Delay(500);
                                                    man2.Location = new Point(431, 450);
                                                    await Task.Delay(500);
                                                    ppl.Remove(ppl.Last());
                                                    Controls.Remove(man2);
                                                    PASSgreen2red(2);
                                                    await Task.Delay(500);
                                                }
                                                break;
                                               
                                        }
                                        break; 
                                    case 2:  //НАПРАВО
                                        switch (autos[3].status)
                                        {
                                            case 1:PASSred2green(1);
                                                await Task.Delay(2000);
                                                man1.Location = new Point(450, 428);
                                                await Task.Delay(500);
                                                man1.Location = new Point(350, 428);
                                                await Task.Delay(500);
                                                man1.Location = new Point(280, 428);
                                                await Task.Delay(500);
                                                ppl.Remove(ppl.Last());
                                                Controls.Remove(man1);
                                                PASSgreen2red(1);
                                                await Task.Delay(500);  //если горит зеленый
                                                break;
                                            case 2:
                                                break;
                                            case 3: //если горит красный
                                                AUTOyellow2green(0);
                                                await Task.Delay(500);
                                                panel0.Location = new Point(268, 337);
                                                await Task.Delay(500);
                                                panel0.Location = new Point(268, 482);
                                                await Task.Delay(500);
                                                panel0.Location = new Point(268, 569);
                                                await Task.Delay(500);
                                                car.Remove(car.Last());
                                                Controls.Remove(panel0);
                                                AUTOyellow2red(0);
                                                await Task.Delay(500);
                                                //пропускаем людей
                                                PASSred2green(1);
                                                await Task.Delay(2000);
                                                man1.Location = new Point(288, 428);
                                                await Task.Delay(500);
                                                man1.Location = new Point(350, 428);
                                                await Task.Delay(500);
                                                man1.Location = new Point(450, 428);
                                                await Task.Delay(500);
                                                ppl.Remove(ppl.Last());
                                                Controls.Remove(man1);
                                                PASSgreen2red(1);
                                                await Task.Delay(500);
                                                break;
                                        }
                                        break;
                                }
                            }
                        }
                            else //людей на улицах (или на 1-ой) нету 
                        {
                            switch (car.Last().direction)
                            {
                                case 1: //ПРЯМО
                                    switch(autos[1].status)
                                    {
                                        case 1: case 2: await Task.Delay(500); break;
                                        case 3: if (autos[3].status == 3)
                                            {
                                                AUTOyellow2green(0);
                                                await Task.Delay(500);
                                                panel0.Location = new Point(286, 337);
                                                await Task.Delay(500);
                                                panel0.Location = new Point(483, 337);
                                                await Task.Delay(500);
                                                panel0.Location = new Point(627, 337);
                                                await Task.Delay(500);
                                                car.Remove(car.Last());
                                                Controls.Remove(panel0);
                                                AUTOyellow2red(0);
                                            }
                                            else
                                            {
                                                await Task.Delay(500);
                                            }
                                            break;

                                    }
                                    break;
                                case 2:  //НАПРАВО
                                    switch(autos[3].status)
                                    {
                                        case 1: case 2: await Task.Delay(500);  //если горит зеленый или желтый
                                            break;
                                        case 3: 
                                            AUTOyellow2green(0);
                                            await Task.Delay(500);
                                            panel0.Location = new Point(268, 337);
                                            await Task.Delay(500);
                                            panel0.Location = new Point(268, 482);
                                            await Task.Delay(500);
                                            panel0.Location = new Point(268, 569);
                                            await Task.Delay(500);
                                            car.Remove(car.Last());
                                            Controls.Remove(panel0);
                                            AUTOyellow2red(0); //если горит красный
                                            break;
                                    }
                                    break;

                            }

                        }
                        break;

                    case 2: //улица 2, светофор 2
                        if (ppl.Any()) //есть ли люди на всех улицах
                        {
                            if (item2 != null) //есть ли люди на 2-ой улице
                            {
                                PASSred2green(1);
                                await Task.Delay(2000);
                                man1.Location = new Point(280, 488);
                                await Task.Delay(500);
                                man1.Location = new Point(360, 488);
                                await Task.Delay(500);
                                man1.Location = new Point(400, 488);
                                await Task.Delay(500);
                                ppl.Remove(ppl.Last());
                                Controls.Remove(man1);
                                PASSgreen2red(1);
                            }
                            if (item3 != null) //есть ли люди на 3 улице
                            {
                                switch (car.Last().direction)
                                {
                                    case 1: //ПРЯМО
                                        switch (autos[0].status)
                                        {
                                            case 1: case 2: await Task.Delay(500); break;
                                            case 3:
                                                if (autos[3].status == 2)
                                                {
                                                    AUTOyellow2green(1);
                                                    await Task.Delay(500);
                                                    panel1.Location = new Point(349, 380);
                                                    await Task.Delay(500);
                                                    panel1.Location = new Point(349, 200);
                                                    await Task.Delay(500);
                                                    panel1.Location = new Point(349, 30);
                                                    await Task.Delay(500);
                                                    car.Remove(car.Last());
                                                    Controls.Remove(panel1);
                                                    AUTOyellow2red(1);

                                                    PASSred2green(3);
                                                    await Task.Delay(2000);
                                                    man3.Location = new Point(350, 188);
                                                    await Task.Delay(500);
                                                    man3.Location = new Point(300, 350);
                                                    await Task.Delay(500);
                                                    man3.Location = new Point(200, 450);
                                                    await Task.Delay(500);
                                                    ppl.Remove(ppl.Last());
                                                    Controls.Remove(man3);
                                                    PASSgreen2red(3);
                                                    await Task.Delay(500);
                                                }
                                                else
                                                {
                                                    PASSred2green(3);
                                                    await Task.Delay(2000);
                                                    man3.Location = new Point(350, 188);
                                                    await Task.Delay(500);
                                                    man3.Location = new Point(300, 188);
                                                    await Task.Delay(500);
                                                    man3.Location = new Point(200, 188);
                                                    await Task.Delay(500);
                                                    ppl.Remove(ppl.Last());
                                                    Controls.Remove(man3);
                                                    PASSgreen2red(3);
                                                    await Task.Delay(500);
                                                }
                                                break;

                                        }
                                        break;
                                    case 2:  //НАПРАВО
                                        switch (autos[0].status)
                                        {
                                            case 1:
                                                PASSred2green(1);
                                                await Task.Delay(2000);
                                                man1.Location = new Point(288, 428);
                                                await Task.Delay(500);
                                                man1.Location = new Point(350, 428);
                                                await Task.Delay(500);
                                                man1.Location = new Point(450, 428);
                                                await Task.Delay(500);
                                                ppl.Remove(ppl.Last());
                                                Controls.Remove(man1);
                                                PASSgreen2red(1);
                                                await Task.Delay(500);  //если горит зеленый
                                                break;
                                            case 2:
                                                break;
                                            case 3: //если горит красный
                                                AUTOyellow2green(1);
                                                await Task.Delay(500);
                                                panel1.Location = new Point(349, 380);
                                                await Task.Delay(500);
                                                panel1.Location = new Point(349, 200);
                                                await Task.Delay(500);
                                                panel1.Location = new Point(349, 30);
                                                await Task.Delay(500);
                                                car.Remove(car.Last());
                                                Controls.Remove(panel1);
                                                AUTOyellow2red(1);
                                                await Task.Delay(500);
                                                //пропускаем людей
                                                PASSred2green(1);
                                                await Task.Delay(2000);
                                                man1.Location = new Point(288, 428);
                                                await Task.Delay(500);
                                                man1.Location = new Point(350, 428);
                                                await Task.Delay(500);
                                                man1.Location = new Point(450, 428);
                                                await Task.Delay(500);
                                                ppl.Remove(ppl.Last());
                                                Controls.Remove(man1);
                                                PASSgreen2red(1);
                                                await Task.Delay(500);
                                                break;
                                        }
                                        break;
                                }
                            }
                        }
                        else //людей на улицах (или на 2-ой) нету 
                        {
                            switch (car.Last().direction)
                            {
                                case 1: //ПРЯМО
                                    switch (autos[0].status)
                                    {
                                        case 1: case 2: await Task.Delay(500); break;
                                        case 3:
                                            if (autos[2].status == 3)
                                            {
                                                AUTOyellow2green(1);
                                                await Task.Delay(500);
                                                panel1.Location = new Point(349, 380);
                                                await Task.Delay(500);
                                                panel1.Location = new Point(349, 200);
                                                await Task.Delay(500);
                                                panel1.Location = new Point(349, 30);
                                                await Task.Delay(500);
                                                car.Remove(car.Last());
                                                Controls.Remove(panel1);
                                                AUTOyellow2red(1);
                                            }
                                            else
                                            {
                                                await Task.Delay(500);
                                            }
                                            break;

                                    }
                                    break;
                                case 2:  //НАПРАВО
                                    switch (autos[2].status)
                                    {
                                        case 1:
                                        case 2:
                                            await Task.Delay(500);  //если горит зеленый или желтый
                                            break;
                                        case 3:
                                            AUTOyellow2green(1);
                                            await Task.Delay(500);
                                            panel1.Location = new Point(349, 380);
                                            await Task.Delay(500);
                                            panel1.Location = new Point(349, 200);
                                            await Task.Delay(500);
                                            panel1.Location = new Point(349, 30);
                                            await Task.Delay(500);
                                            car.Remove(car.Last());
                                            Controls.Remove(panel1);
                                            AUTOyellow2red(1);//если горит красный
                                            break;
                                    }
                                    break;

                            }

                        }
                        break;
                    case 3: //улица 3, светофор 3
                        if (ppl.Any()) //есть ли люди на всех улицах
                        {
                            if (item3 != null) //есть ли люди на 3-ой улице
                            {
                                PASSred2green(2);
                                await Task.Delay(2000);
                                man2.Location = new Point(431, 250);
                                await Task.Delay(500);
                                man2.Location = new Point(431, 350);
                                await Task.Delay(500);
                                man2.Location = new Point(431, 450);
                                await Task.Delay(500);
                                ppl.Remove(ppl.Last());
                                Controls.Remove(man2);
                                PASSgreen2red(2);
                            }
                            if (item4 != null) //есть ли люди на 4 улице
                            {
                                switch (car.Last().direction)
                                {
                                    case 1: //ПРЯМО
                                        switch (autos[1].status)
                                        {
                                            case 1: case 2: await Task.Delay(500); break;
                                            case 3:
                                                if (autos[3].status == 2)
                                                {
                                                    AUTOyellow2green(2);
                                                    await Task.Delay(500);
                                                    panel2.Location = new Point(300, 271);
                                                    await Task.Delay(500);
                                                    panel2.Location = new Point(200, 200);
                                                    await Task.Delay(500);
                                                    panel2.Location = new Point(100, 30);
                                                    await Task.Delay(500);
                                                    car.Remove(car.Last());
                                                    Controls.Remove(panel2);
                                                    AUTOyellow2red(2);

                                                    PASSred2green(0);
                                                    await Task.Delay(2000);
                                                    man0.Location = new Point(188, 280);
                                                    await Task.Delay(500);
                                                    man0.Location = new Point(188, 344);
                                                    await Task.Delay(500);
                                                    man0.Location = new Point(188, 400);
                                                    await Task.Delay(500);
                                                    ppl.Remove(ppl.Last());
                                                    Controls.Remove(man0);
                                                    PASSgreen2red(0);
                                                    await Task.Delay(500);

                                                }
                                                else
                                                {
                                                    PASSred2green(0);
                                                    await Task.Delay(2000);
                                                    man0.Location = new Point(188, 280);
                                                    await Task.Delay(500);
                                                    man0.Location = new Point(188, 344);
                                                    await Task.Delay(500);
                                                    man0.Location = new Point(188, 400);
                                                    await Task.Delay(500);
                                                    ppl.Remove(ppl.Last());
                                                    Controls.Remove(man0);
                                                    PASSgreen2red(0);
                                                    await Task.Delay(500);
                                                }
                                                break;

                                        }
                                        break;
                                    case 2:  //НАПРАВО
                                        switch (autos[1].status)
                                        {
                                            case 1:
                                                PASSred2green(3);
                                                await Task.Delay(2000);
                                                man3.Location = new Point(350, 188);
                                                await Task.Delay(500);
                                                man3.Location = new Point(300, 188);
                                                await Task.Delay(500);
                                                man3.Location = new Point(200, 188);
                                                await Task.Delay(500);
                                                ppl.Remove(ppl.Last());
                                                Controls.Remove(man3);
                                                PASSgreen2red(3);
                                                await Task.Delay(5000); //если горит зеленый
                                                break;
                                            case 2:
                                                break;
                                            case 3: //если горит красный
                                                AUTOyellow2green(2);
                                                await Task.Delay(500);
                                                panel2.Location = new Point(300, 271);
                                                await Task.Delay(500);
                                                panel2.Location = new Point(200, 170);
                                                await Task.Delay(500);
                                                panel2.Location = new Point(200, 60);
                                                await Task.Delay(500);
                                                car.Remove(car.Last());
                                                Controls.Remove(panel2);
                                                AUTOyellow2red(2);
                                                await Task.Delay(500);
                                                //пропускаем людей
                                                PASSred2green(3);
                                                await Task.Delay(2000);
                                                man3.Location = new Point(350, 188);
                                                await Task.Delay(500);
                                                man3.Location = new Point(300, 188);
                                                await Task.Delay(500);
                                                man3.Location = new Point(200, 188);
                                                await Task.Delay(500);
                                                ppl.Remove(ppl.Last());
                                                Controls.Remove(man3);
                                                PASSgreen2red(3);
                                                await Task.Delay(500);
                                                break;
                                        }
                                        break;
                                }
                            }
                        }
                        else //людей на улицах (или на 3-ой) нету 
                        {
                            switch (car.Last().direction)
                            {
                                case 1: //ПРЯМО
                                    switch (autos[1].status)
                                    {
                                        case 1: case 2: await Task.Delay(500); break;
                                        case 3:
                                            if (autos[3].status == 3)
                                            {
                                                AUTOyellow2green(2);
                                                await Task.Delay(500);
                                                panel2.Location = new Point(300, 271);
                                                await Task.Delay(500);
                                                panel2.Location = new Point(200, 200);
                                                await Task.Delay(500);
                                                panel2.Location = new Point(200, 30);
                                                await Task.Delay(500);
                                                car.Remove(car.Last());
                                                Controls.Remove(panel2);
                                                AUTOyellow2red(2);
                                                await Task.Delay(500);
                                            }
                                            else
                                            {
                                                await Task.Delay(500);
                                            }
                                            break;

                                    }
                                    break;
                                case 2:  //НАПРАВО
                                    switch (autos[1].status)
                                    {
                                        case 1:
                                        case 2:
                                            await Task.Delay(500);  //если горит зеленый или желтый
                                            break;
                                        case 3:
                                            AUTOyellow2green(2);
                                            await Task.Delay(500);
                                            panel2.Location = new Point(300, 271);
                                            await Task.Delay(500);
                                            panel2.Location = new Point(200, 200);
                                            await Task.Delay(500);
                                            panel2.Location = new Point(100, 30);
                                            await Task.Delay(500);
                                            car.Remove(car.Last());
                                            Controls.Remove(panel2);
                                            AUTOyellow2red(2);
                                            await Task.Delay(500); //если горит красный
                                            break;
                                    }
                                    break;

                            }

                        }
                        break;
                    case 4: //улица 4, светофор 4
                        if (ppl.Any()) //есть ли люди на всех улицах
                        {
                            if (item4 != null) //есть ли люди на 4-ой улице
                            {
                                PASSred2green(3);
                                await Task.Delay(2000);
                                man3.Location = new Point(415, 188);
                                await Task.Delay(500);
                                man3.Location = new Point(300, 188);
                                await Task.Delay(500);
                                man3.Location = new Point(200, 188);
                                await Task.Delay(500);
                                ppl.Remove(ppl.Last());
                                Controls.Remove(man3);
                                PASSgreen2red(3);
                            }
                            if (item != null) //есть ли люди на 4 улице
                            {
                                switch (car.Last().direction)
                                {
                                    case 1: //ПРЯМО
                                        switch (autos[0].status)
                                        {
                                            case 1: case 2: await Task.Delay(500); break;
                                            case 3:
                                                if (autos[2].status == 2)
                                                {
                                                    AUTOyellow2green(3);
                                                    await Task.Delay(500);
                                                    panel3.Location = new Point(278, 276);
                                                    await Task.Delay(500);
                                                    panel3.Location = new Point(100, 276);
                                                    await Task.Delay(500);
                                                    panel3.Location = new Point(50, 276);
                                                    await Task.Delay(500);
                                                    car.Remove(car.Last());
                                                    Controls.Remove(panel3);
                                                    AUTOyellow2red(3);

                                                    PASSred2green(1);
                                                    await Task.Delay(2000);
                                                    man1.Location = new Point(288, 428);
                                                    await Task.Delay(500);
                                                    man1.Location = new Point(350, 428);
                                                    await Task.Delay(500);
                                                    man1.Location = new Point(450, 428);
                                                    await Task.Delay(500);
                                                    ppl.Remove(ppl.Last());
                                                    Controls.Remove(man1);
                                                    PASSgreen2red(1);
                                                    await Task.Delay(500);

                                                }
                                                else
                                                {
                                                    PASSred2green(1);
                                                    await Task.Delay(2000);
                                                    man1.Location = new Point(288, 428);
                                                    await Task.Delay(500);
                                                    man1.Location = new Point(350, 428);
                                                    await Task.Delay(500);
                                                    man1.Location = new Point(450, 428);
                                                    await Task.Delay(500);
                                                    ppl.Remove(ppl.Last());
                                                    Controls.Remove(man1);
                                                    PASSgreen2red(1);
                                                    await Task.Delay(500);
                                                }
                                                break;

                                        }
                                        break;
                                    case 2:  //НАПРАВО
                                        switch (autos[0].status)
                                        {
                                            case 1:
                                                PASSred2green(0);
                                                await Task.Delay(2000);
                                                man0.Location = new Point(188, 280);
                                                await Task.Delay(500);
                                                man0.Location = new Point(188, 344);
                                                await Task.Delay(500);
                                                man0.Location = new Point(188, 400);
                                                await Task.Delay(500);
                                                ppl.Remove(ppl.Last());
                                                Controls.Remove(man0);
                                                PASSgreen2red(0);
                                                await Task.Delay(500); //если горит зеленый
                                                break;
                                            case 2:
                                                break;
                                            case 3: //если горит красный
                                                AUTOyellow2green(3);
                                                await Task.Delay(500);
                                                panel3.Location = new Point(278, 276);
                                                await Task.Delay(500);
                                                panel3.Location = new Point(100, 276);
                                                await Task.Delay(500);
                                                panel3.Location = new Point(50, 276);
                                                await Task.Delay(500);
                                                car.Remove(car.Last());
                                                Controls.Remove(panel3);
                                                AUTOyellow2red(3);
                                                await Task.Delay(500);
                                                //пропускаем людей
                                                PASSred2green(0);
                                                await Task.Delay(2000);
                                                man0.Location = new Point(188, 280);
                                                await Task.Delay(500);
                                                man0.Location = new Point(188, 344);
                                                await Task.Delay(500);
                                                man0.Location = new Point(188, 400);
                                                await Task.Delay(500);
                                                ppl.Remove(ppl.Last());
                                                Controls.Remove(man0);
                                                PASSgreen2red(0);
                                                await Task.Delay(500);
                                                break;
                                        }
                                        break;
                                }
                            }
                        }
                        else //людей на улицах (или на 3-ой) нету 
                        {
                            switch (car.Last().direction)
                            {
                                case 1: //ПРЯМО
                                    switch (autos[0].status)
                                    {
                                        case 1: case 2: await Task.Delay(500); break;
                                        case 3:
                                            if (autos[2].status == 3)
                                            {
                                                AUTOyellow2green(3);
                                                await Task.Delay(500);
                                                panel3.Location = new Point(278, 276);
                                                await Task.Delay(500);
                                                panel3.Location = new Point(100, 276);
                                                await Task.Delay(500);
                                                panel3.Location = new Point(50, 276);
                                                await Task.Delay(500);
                                                car.Remove(car.Last());
                                                Controls.Remove(panel3);
                                                AUTOyellow2red(3);
                                                await Task.Delay(500);
                                            }
                                            else
                                            {
                                                await Task.Delay(500);
                                            }
                                            break;

                                    }
                                    break;
                                case 2:  //НАПРАВО
                                    switch (autos[0].status)
                                    {
                                        case 1:
                                        case 2:
                                            await Task.Delay(500);  //если горит зеленый или желтый
                                            break;
                                        case 3:
                                            AUTOyellow2green(3);
                                            await Task.Delay(500);
                                            panel3.Location = new Point(278, 276);
                                            await Task.Delay(500);
                                            panel3.Location = new Point(100, 276);
                                            await Task.Delay(500);
                                            panel3.Location = new Point(50, 276);
                                            await Task.Delay(500);
                                            car.Remove(car.Last());
                                            Controls.Remove(panel3);
                                            AUTOyellow2red(3);
                                            await Task.Delay(500); //если горит красный
                                            break;
                                    }
                                    break;

                            }

                        }
                        break;

                }
            }
            else //НЕТУ МАШИН, ЕСТЬ ЛЮДИ ИЛИ НЕТУ АМШИН, НЕТ ЛЮДЕЙ
            {
                
                if (ppl.Any())
                {
                    switch (ppl.Last().street)
                    {
                        case 1:
                            PASSred2green(0);
                            await Task.Delay(2000);
                            man0.Location = new Point(188, 280);
                            await Task.Delay(500);
                            man0.Location = new Point(188, 344);
                            await Task.Delay(500);
                            man0.Location = new Point(188, 400);
                            await Task.Delay(500);
                            ppl.Remove(ppl.Last());
                            Controls.Remove(man0);
                            PASSgreen2red(0);
                            break;

                        case 2:
                            PASSred2green(1);
                            await Task.Delay(2000);
                            man1.Location = new Point(288, 428);
                            await Task.Delay(500);
                            man1.Location = new Point(350, 428);
                            await Task.Delay(500);
                            man1.Location = new Point(450, 428);
                            await Task.Delay(500);
                            ppl.Remove(ppl.Last());
                            Controls.Remove(man1);
                            PASSgreen2red(1);
                            await Task.Delay(500);
                            break;
                        case 3:
                            PASSred2green(2);
                            await Task.Delay(2000);
                            man2.Location = new Point(431, 250);
                            await Task.Delay(500);
                            man2.Location = new Point(431, 350);
                            await Task.Delay(500);
                            man2.Location = new Point(431, 450);
                            await Task.Delay(500);
                            ppl.Remove(ppl.Last());
                            Controls.Remove(man2);
                            PASSgreen2red(2);
                            await Task.Delay(500);
                            break;
                        case 4:
                            PASSred2green(3);
                            await Task.Delay(2000);
                            man3.Location = new Point(350, 188);
                            await Task.Delay(500);
                            man3.Location = new Point(300, 188);
                            await Task.Delay(500);
                            man3.Location = new Point(200, 188);
                            await Task.Delay(500);
                            ppl.Remove(ppl.Last());
                            Controls.Remove(man3);
                            PASSgreen2red(3);
                            await Task.Delay(500);
                            break;
                    }
                }
                else
                {
                    await Task.Delay(500);
                    return;
                }



            }
            async void AUTOyellow2green(int num)
            {
                for (int ix = num; ix == num; ix++)
                {
                    autos[ix].status = 2;
                    Controls["tf" + ix].BackColor = Color.Yellow;
                    await Task.Delay(500);
                    autos[ix].status = 1;
                    Controls["tf" + ix].BackColor = Color.Green;
                }

            }
            async void AUTOyellow2red(int num)
            {
                for (int ix = num; ix == num; ix++)
                {
                    autos[ix].status = 2;
                    Controls["tf" + ix].BackColor = Color.Yellow;
                    await Task.Delay(500);
                    autos[ix].status = 3;
                    Controls["tf" + ix].BackColor = Color.Red;
                }
            }
             void PASSred2green(int num)
            {
                for (int ix = num; ix == num; ix++)
                {
                    passengers[ix].status = 1;
                    Controls["peopletl" + ix].BackColor = Color.Green;
                    Controls["peopletl" + ix + "_"].BackColor = Color.Green;
                }

            }
            void PASSgreen2red(int num)
            {
                for (int ix = num; ix == num; ix++)
                {
                    passengers[ix].status = 3;
                    Controls["peopletl" + ix].BackColor = Color.Red;
                    Controls["peopletl" + ix + "_"].BackColor = Color.Red;
                }
            }

        }
       async private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10000; i++)
            {

               
                changelight();
                await Task.Delay(5000);
            }
            
        }

    }
    }

