namespace TxtFilterer
{
    public class xWord
    {
        public string title;
        public bool isPresent;
        public xWord(string t, bool i)
        {
            title = t;
            isPresent = i;
        }

        public string isPresentStr()
        {
            return isPresent == true ? "Да" : "Нет";
        }

    }
}
