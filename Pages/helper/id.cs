public class ID{
    static readonly string FILE_NAME = "./Json/id.txt";

    public static int New(){
        try{
            int intId = 0;
            if (File.Exists(FILE_NAME)){
                string stringId = File.ReadAllText(FILE_NAME);
                if (int.TryParse(stringId, out intId)){
                    intId++;
                }
            }
            File.WriteAllText(FILE_NAME, intId.ToString());
            return intId;
        } catch (Exception e) {
            Console.WriteLine(e);
            return 0;
        }
    }
}