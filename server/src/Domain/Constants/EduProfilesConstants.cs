using Domain.Enums;

namespace Domain.Constants
{
    public static class EduProfilesConstants
    {
        public static readonly Dictionary<EduProfileType, string> Titles = new Dictionary<EduProfileType, string> {
            {EduProfileType.BakOfoUp, "Бакалавриат ОФО Уголовно-правовой профиль"},
            {EduProfileType.BakZfoUp, "Бакалавриат ЗФО Уголовно-правовой профиль"},
            {EduProfileType.BakOzfoUp, "Бакалавриат ОЗФО Уголовно-правовой профиль"},
            {EduProfileType.BakOfoGp, "Бакалавриат ОФО Гражданско-правовой профиль"},
            {EduProfileType.BakZfoGp, "Бакалавриат ЗФО Гражданско-правовой профиль"},
            {EduProfileType.BakOzfoGp, "Бакалавриат ОЗФО Гражданско-правовой профиль"},
            {EduProfileType.SpecOfoSd, "Специалитет ОФО Судебная деятельность"},
            {EduProfileType.MagOfoPo, "Магистратура ОФО Правовое обеспечение гражданского оборота и предпринимательства"},
            {EduProfileType.MagZfoPo, "Магистратура ЗФО Правовое обеспечение гражданского оборота и предпринимательства"},
            {EduProfileType.MagOfoTp, "Магистратура ОФО Теория и практика применения законодательства в уголовно-правовой сфере"},
            {EduProfileType.MagZfoTp, "Магистратура ЗФО Теория и практика применения законодательства в уголовно-правовой сфере"},
            {EduProfileType.AspOfoGp, "Аспирантура Теоретико-исторические правовые науки (ОЧНАЯ ФОРМА ОБУЧЕНИЯ)"},
            {EduProfileType.AspOfoUgp, "Аспирантура Уголовно-правовые науки (ОЧНАЯ ФОРМА ОБУЧЕНИЯ)"},
            {EduProfileType.AspOfoTip, "Аспирантура ОФО Теория и история права и государства, история учений о праве и государстве"},
            {EduProfileType.AspZfoTip, "Аспирантура ЗФО Теория и история права и государства, история учений о праве и государстве"},
            {EduProfileType.AspOfoUp, "Аспирантура ОФО Уголовный процесс"},
            {EduProfileType.AspZfoUp, "Аспирантура ЗФО Уголовный процесс"},
            {EduProfileType.AspOfoKs, "Аспирантура ОФО Криминалистика; судебно-экспертная деятельность; оперативно-розыскная деятельность"},
            {EduProfileType.AspZfoKs, "Аспирантура ЗФО Криминалистика; судебно-экспертная деятельность; оперативно-розыскная деятельность"},
        };
    }
}
