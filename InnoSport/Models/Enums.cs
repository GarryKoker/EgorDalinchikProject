// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoSport.Models
{
    public enum Roles
        {
            Пользователь,
            Спортсмен,
            Тренер,
            Администратор,
            ГлавныйАдминистратор
        }

    public enum Sections
    {
        ФитнесЗал,
        Футбол,
        Баскетбол,
        Теннис,
        НастольныйТеннис,
        Плавание,
        Хоккей,
        ФигурноеКатание
    }
}
