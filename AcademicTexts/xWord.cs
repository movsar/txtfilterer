namespace TxtFilterer
{
    public class xWord
    {
        public string title;
        private bool inA;
        private bool inB;

        public string InA()
        {
            return inA == true ? "Да" : "Нет";
        }
        public string InB()
        {
            return inB == true ? "Да" : "Нет";
        }

        public xWord(string title, bool inA, bool inB)
        {
            this.title = title;
            this.inA = inA;
            this.inB = inB;
        }
    }
}
