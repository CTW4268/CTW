GetBingPic.GetPicP gp = new GetBingPic.GetPicP();

Console.Write("y:");

int yy=0,m=0,d = 0;
string y = Console.ReadLine();
if (string.IsNullOrEmpty(y)){
    int[] r = gp.GetPageIndex();
    gp.GetPic(r[0],r[1]);
    Environment.Exit(0);
}else{
    yy = int.Parse(y);
    Console.Write("m:");
    m = int.Parse(Console.ReadLine());
    Console.Write("d:");
    m = int.Parse(Console.ReadLine());
}
int[] rr = gp.GetPageIndex(new Datetime(yy,m,d));
gp.GetPic(rr[0],rr[1]);