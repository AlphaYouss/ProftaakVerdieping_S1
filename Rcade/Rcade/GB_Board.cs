using System.Collections.Generic;

namespace Rcade
{
    class GB_Board
    {
        public Dictionary<int, string> fields { get; private set; }
        public List<int> doubleThrowFields { get; private set; }
        public GB_SpecialFields specialfields { get; private set; }
        public GB_Board(GB_Dice dice)
        {
            specialfields = new GB_SpecialFields(dice);
            fields = new Dictionary<int, string>();
            doubleThrowFields = new List<int>() { 5, 9, 14, 18, 23, 27, 32, 36, 41, 45, 50, 54, 59 };
        }

        public void GenerateBoard()
        {
            for (int i = 0; i <= 63; i++)
            {
                if (doubleThrowFields.Contains(i))
                {
                    fields.Add(i, "dubbeleworp");
                }

                if (!fields.ContainsKey(i))
                {
                    switch (i)
                    {
                        default:
                            fields.Add(i, null);
                            break;
                        case 6:
                            fields.Add(i, "brug");
                            break;
                        case 19:
                            fields.Add(i, "herberg");
                            break;
                        case 31:
                            fields.Add(i, "put");
                            break;
                        case 42:
                            fields.Add(i, "doolhof");
                            break;
                        case 52:
                            fields.Add(i, "gevangenis");
                            break;
                        case 58:
                            fields.Add(i, "dood");
                            break;
                        case 63:
                            fields.Add(i, "einde");
                            break;
                    }
                }
            }
        }
    }
}
