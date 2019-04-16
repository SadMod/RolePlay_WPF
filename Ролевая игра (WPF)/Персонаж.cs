﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ролевая_игра__WPF_
{
    public class Персонаж
    {
        public uint ID { get; protected set; }

        public string Имя { get; protected set; }
        public string Раса { get; protected set; }
        public uint Возраст { get; protected set; }
        public bool Пол { get; protected set; } //Если true, то мужской, если false, то женский

        public bool[] Состояние = new bool[5] { false, false, false, false, false };// ослаблен, болен, отравлен, парализован, мёртв
        public bool Может_говорить { get; protected set; } = true;
        public bool Может_двигаться { get; protected set; } = true;

        public uint Максимальное_здоровье { get; protected set; }
        public uint Очки_Здоровья { get; protected set; }
        public uint Очки_Опыта { get; protected set; } = 0;

        /// <summary>
        /// Создание нового персонажа
        /// </summary>
        /// <param name="ID">Уникальный номер (автоподсчет)</param>
        /// <param name="Имя">Имя героя</param>
        /// <param name="Пол">Пол героя</param>
        /// <param name="Возраст">Возраст героя</param>
        /// <param name="Раса">Раса героя</param>
        public Персонаж(uint ID, string Имя, bool Пол, uint Возраст, string Раса)
        {
            this.ID = ID;
            this.Имя = Имя;
            this.Пол = Пол;
            this.Возраст = Возраст;
            this.Раса = Раса;

            Установить_константы();
        }
        public Персонаж(uint ID, string Имя, bool Пол, uint Возраст, string Раса, bool Ослаблен, bool Болен, bool Отравлен, bool Парализован, bool Мертв, bool Может_говорить, bool Может_двигаться, uint Максимальное_здоровье, uint Очки_Здоровья, uint Очки_Опыта)
        {
            this.ID = ID;
            this.Имя = Имя;
            this.Пол = Пол;
            this.Возраст = Возраст;
            this.Раса = Раса;
            bool[] Сжатые_состояния = { Ослаблен, Болен, Отравлен, Парализован, Мертв };
            Состояние = Сжатые_состояния;
            this.Может_говорить = Может_говорить;
            this.Может_двигаться = Может_двигаться;
            this.Максимальное_здоровье = Максимальное_здоровье;
            this.Очки_Здоровья = Очки_Здоровья;
            this.Очки_Опыта = Очки_Опыта;
        }
        protected virtual void Установить_константы()
        {
            if(Раса == "человек")
            {
                Максимальное_здоровье = 100;
                Очки_Здоровья = Максимальное_здоровье;
            }
            if (Раса == "гном")
            {
                Максимальное_здоровье = 150;
                Очки_Здоровья = Максимальное_здоровье;
            }
            if (Раса == "эльф" || Раса == "эльфийка")
            {
                Максимальное_здоровье = 130;
                Очки_Здоровья = Максимальное_здоровье;
            }
            if (Раса == "орк")
            {
                Максимальное_здоровье = 200;
                Очки_Здоровья = Максимальное_здоровье;
            }
            if (Раса == "гоблин")
            {
                Максимальное_здоровье = 120;
                Очки_Здоровья = Максимальное_здоровье;
            }
        }
        /// <param name="value">Сколько опыта добавить?</param>
        public void Добавить_ОчкиОпыта(uint value)
        {
            Очки_Опыта += value;
        }
        public override string ToString()
        {
            string Информация = "";
            Информация += $"\n - - Информация о состоянии - -\n";

            Дебаффы(Состояние);

            if (Может_говорить)
                Информация += $"{Имя} может говорить\n";
            else
                Информация += $"{Имя} говорить не может\n";

            if (Может_двигаться)
                Информация += $"{Имя} может двигаться навстречу приключениям\n";
            else
                Информация += $"{Имя}, к сожалению, навстречу приключениям двигаться не может\n";

            Информация += $"\n - - Информация о характеристиках - -\n";

            Информация += $"Текущее здоровье: {Очки_Здоровья} HP\n";
            Информация += $"Максимальное здоровье: {Максимальное_здоровье} HP\n";
            Информация += $"Текущее количество опыта: {Очки_Опыта} EXP\n";

            Информация += $"\n - - Информация об отрицательных эффектах - -\n";
            Дебаффы(Состояние);
            return Информация;
        }
        static public string Лет_Лета_Год(uint Возраст)
        {
            if (Возраст == 1 || Возраст == 21 || Возраст == 31 || Возраст == 41 || Возраст == 51 || Возраст == 61 || Возраст == 71 || Возраст == 81 || Возраст == 91)
                return Возраст + " год";
            else if ((Возраст >= 2 && Возраст <= 4) || (Возраст >= 22 && Возраст <= 24) || (Возраст >= 32 && Возраст <= 34) || (Возраст >= 42 && Возраст <= 44) || (Возраст >= 52 && Возраст <= 54) || (Возраст >= 62 && Возраст <= 64) || (Возраст >= 72 && Возраст <= 74) || (Возраст >= 82 && Возраст <= 84) || (Возраст >= 92 && Возраст <= 94))
                return Возраст + " года";
            else if ((Возраст >= 5 && Возраст <= 20) || (Возраст >= 25 && Возраст <= 30) || (Возраст >= 35 && Возраст <= 40) || (Возраст >= 45 && Возраст <= 50) || (Возраст >= 55 && Возраст <= 60) || (Возраст >= 65 && Возраст <= 70) || (Возраст >= 75 && Возраст <= 80) || (Возраст >= 85 && Возраст <= 90) || (Возраст >= 95 && Возраст <= 100))
                return Возраст + " лет";
            return "";
        }
        protected string Дебаффы(bool[] Состояние)
        {
            string Информация = "";
            if (Состояние[0] == false && Состояние[1] == false && Состояние[2] == false && Состояние[3] == false && Состояние[4] == false)
            {
                Информация += $"{Имя} не имеет отрицательных эффектов\n";
            }
            if (Состояние[4] == true)
            {
                if (Пол)
                    Информация += $"Будут сложены и увековечены легенды о подвигах великого героя {Имя}. (Герой мертв)\n";
                else
                    Информация += $"Будут сложены и увековечены легенды о подвигах великой героини {Имя}. (Героиня мертва)\n";
            }
            else
            {
                if (Состояние[0] == true)
                {
                    if (Пол)
                        Информация += $"{Имя} ослаблен\n";
                    else
                        Информация += $"{Имя} ослаблена\n";
                }
                if (Состояние[1] == true)
                {
                    if (Пол)
                        Информация += $"{Имя} болен\n";
                    else
                        Информация += $"{Имя} больна\n";
                }
                if (Состояние[2] == true)
                {
                    if (Пол)
                        Информация += $"{Имя} отравлен\n";
                    else
                        Информация += $"{Имя} отравлена\n";
                }
            }
            return Информация;
        }

        public void ИзменениеСостоянияЗдоровья(string действие, uint сила_воздействия)
        {
            if (действие == "урон")
            {
                if (Очки_Здоровья < сила_воздействия)
                    Очки_Здоровья = 0;
                else
                    Очки_Здоровья -= сила_воздействия;
            }
            if (действие == "лечение")
            {
                Очки_Здоровья += сила_воздействия;
                if (Очки_Здоровья > Максимальное_здоровье)
                    Очки_Здоровья = Максимальное_здоровье;
            }
            ИзменениеСостоянияЭффектов();
        }
        private void ИзменениеСостоянияЭффектов()
        {
            int ДесятьПроцентовОтHP = (int)Максимальное_здоровье / 10;
            //если здоровье персонажа становится <10%, персонаж переходит из состояния «здоров» в состояние «ослаблен».
            if (Очки_Здоровья <= ДесятьПроцентовОтHP)
            {
                Состояние[0] = true; //ослаблен
            }
            if(Очки_Здоровья >= ДесятьПроцентовОтHP)
            {
                Состояние[0] = false; //ослаблен
            }
            if (Очки_Здоровья == 0)
            {
                Состояние[0] = false; //ослаблен
                Состояние[1] = false; //болен
                Состояние[2] = false; //отравлен
                Состояние[3] = false; //парализован
                Состояние[4] = true;  //мёртв
            }
        }

    }

    public class Персонаж_с_магией : Персонаж
    {
        public uint Максимальная_мана { get; protected set; }
        public uint Очки_Маны { get; protected set; }

        public Персонаж_с_магией(uint ID, string Имя, bool Пол, uint Возраст, string Раса) : base(ID, Имя, Пол, Возраст, Раса)
        {
            this.ID = ID;
            this.Имя = Имя;
            this.Пол = Пол;
            this.Возраст = Возраст;
            this.Раса = Раса;
            Установить_константы();
        }
        public Персонаж_с_магией(uint ID, string Имя, bool Пол, uint Возраст, string Раса, bool Ослаблен, bool Болен, bool Отравлен, bool Парализован, bool Мертв, bool Может_говорить, bool Может_двигаться, uint Максимальное_здоровье, uint Очки_Здоровья, uint Очки_Опыта, uint Максимальная_мана, uint Очки_Маны): base(ID, Имя, Пол, Возраст, Раса, Ослаблен, Болен, Отравлен, Парализован, Мертв, Может_говорить, Может_двигаться, Максимальное_здоровье, Очки_Здоровья, Очки_Опыта)
        {
            this.ID = ID;
            this.Имя = Имя;
            this.Пол = Пол;
            this.Возраст = Возраст;
            this.Раса = Раса;
            bool[] Сжатые_состояния = { Ослаблен, Болен, Отравлен, Парализован, Мертв };
            Состояние = Сжатые_состояния;
            this.Может_говорить = Может_говорить;
            this.Может_двигаться = Может_двигаться;
            this.Максимальное_здоровье = Максимальное_здоровье;
            this.Очки_Здоровья = Очки_Здоровья;
            this.Очки_Опыта = Очки_Опыта;
            this.Максимальная_мана = Максимальная_мана;
            this.Очки_Маны = Очки_Маны;
        }
        protected override void Установить_константы()
        {
            if (Раса == "человек")
            {
                Максимальное_здоровье = 100;
                Очки_Здоровья = Максимальное_здоровье;
                Максимальная_мана = 100;
                Очки_Маны = Максимальная_мана;
            }
            if (Раса == "гном")
            {
                Максимальное_здоровье = 150;
                Очки_Здоровья = Максимальное_здоровье;
                Максимальная_мана = 50;
                Очки_Маны = Максимальная_мана;
            }
            if (Раса == "эльф" || Раса == "эльфийка")
            {
                Максимальное_здоровье = 130;
                Очки_Здоровья = Максимальное_здоровье;
                Максимальная_мана = 150;
                Очки_Маны = Максимальная_мана;
            }
            if (Раса == "орк")
            {
                Максимальное_здоровье = 200;
                Очки_Здоровья = Максимальное_здоровье;
                Максимальная_мана = 50;
                Очки_Маны = Максимальная_мана;
            }
            if (Раса == "гоблин")
            {
                Максимальное_здоровье = 120;
                Очки_Здоровья = Максимальное_здоровье;
                Максимальная_мана = 130;
                Очки_Маны = Максимальная_мана;
            }
        }

        public override string ToString()
        {
            string Информация = "";
            Информация += $"\n - - Информация о состоянии - -\n";

            Информация += Дебаффы(Состояние);

            if (Может_говорить)
                Информация += $"{Имя} может говорить\n";
            else
                Информация += $"{Имя} говорить не может\n";

            if (Может_двигаться)
                Информация += $"{Имя} может двигаться навстречу приключениям\n";
            else
                Информация += $"{Имя}, к сожалению, навстречу приключениям двигаться не может\n";

            Информация += $"\n - - Информация о характеристиках - -\n";

            Информация += $"Текущее здоровье: {Очки_Здоровья} HP\n";
            Информация += $"Максимальное здоровье: {Максимальное_здоровье} HP\n";
            Информация += $"Текущее количество маны: {Очки_Маны} MP\n";
            Информация += $"Максимальное количество маны: {Максимальная_мана} MP\n";
            Информация += $"Текущее количество опыта: {Очки_Опыта} EXP\n";

            return Информация;
        }

        public void ИзменениеСостоянияМаны(string действие, uint сила_воздействия)
        {
            if (действие == "расходование")
                Очки_Маны -= сила_воздействия;
            if (действие == "восполнение")
            {
                Очки_Маны += сила_воздействия;
                if (Очки_Маны > Максимальная_мана)
                    Очки_Маны = Максимальная_мана;
            }
        }
    }
}
