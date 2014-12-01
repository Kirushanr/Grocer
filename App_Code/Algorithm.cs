using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;

/// <summary>
/// Summary description for Algorithm
/// </summary>
public class Algorithm
{
	public Algorithm()
	{
    }

    static void Main(string[] args)
    {
        string file = @"big_test.csv";
        string sup = "60";

        if (args.Length > 0)
        {
            file = args[0];

        }
        if (args.Length == 2)
        {
            sup = args[1];
          
        }


        double support = double.Parse(sup);

        CSVReader cr = new CSVReader();
        ItemSet data = cr.Read(file);




        Algorithm p = new Algorithm();
        ItemSet a = p.apriori(data, support);
        for (int i = 0; i < a.Count; i++)
        {
            Console.WriteLine(a.arr[i].ToString());
            ItemSet cur = (ItemSet)a.arr[i];

            for (int j = 0; j < cur.Count; j++)
            {
                ItemSet now = (ItemSet)cur.arr[j];
                now.Sort();
                for (int k = 0; k < now.Count; k++)
                {

                   // Console.WriteLine("ID : " + ((DataItem)now.arr[k]).Id + ",the value is :(" + ((DataItem)now.arr[k]).ItemName + ")  ");

                }
                //Console.WriteLine("  Number of apperances:" + now.ICount);
            }

        }

        Console.Read();
    }

    private void RuleG(ItemSet a)
    {
    }

    private ItemSet FindOneColSet(ItemSet data, double support)
    {
        ItemSet cur = null;
        ItemSet result = new ItemSet();

        ItemSet set = null;
        ItemSet newset = null;
        DataItem cd = null;
        DataItem td = null;
        bool flag = true;

        for (int i = 0; i < data.Count; i++)
        {
            cur = (ItemSet)data.arr[i];
            for (int j = 0; j < cur.Count; j++)
            {
                cd = (DataItem)cur.arr[j];
                for (int n = 0; n < result.Count; n++)
                {

                    set = (ItemSet)result.arr[n];
                    td = (DataItem)set.arr[0];
                    Console.WriteLine(cd.ItemName + " " + td.ItemName);
                    if (cd.Id == td.Id)
                    {
                        
                        set.ICount++;
                        flag = false;
                        break;

                    }
                    flag = true;
                }
                if (flag)
                {
                    newset = new ItemSet();
                    newset.Add(cd);
                    result.Add(newset);
                    newset.ICount = 1;
                }
            }



        }
        ItemSet finalResult = new ItemSet();
        for (int i = 0; i < result.Count; i++)
        {
            ItemSet con = (ItemSet)result.arr[i];
            if (con.ICount >= support)
            {

                finalResult.Add(con);
            }


        }
        //finalResult.Sort();    
        return finalResult;


    }


    private ItemSet apriori(ItemSet data, double support)
    {

        ItemSet result = new ItemSet();
        ItemSet li = new ItemSet();
        ItemSet conList = new ItemSet();
        ItemSet subConList = new ItemSet();
        ItemSet subDataList = new ItemSet();
        ItemSet CurList = null;
        ItemSet subList = null;
        int k = 2;
        li.Add(new ItemSet());
        li.Add(this.FindOneColSet(data, support));

        while (((ItemSet)li.arr[k - 1]).Count != 0)
        {
            Console.WriteLine(k - 1);
            conList = AprioriGenerate((ItemSet)li.arr[k - 1], k - 1, support);
            for (int i = 0; i < data.Count; i++)
            {
                subDataList = SubSet((ItemSet)data.arr[i], k);
                for (int j = 0; j < subDataList.Count; j++)
                {
                    subList = (ItemSet)subDataList.arr[j];
                    for (int n = 0; n < conList.Count; n++)
                    {
                        ((ItemSet)subDataList.arr[j]).Sort();
                        ((ItemSet)conList.arr[n]).Sort();
                        CurList = (ItemSet)conList.arr[n];
                        if (subList.Equals(CurList))
                        {
                            ((ItemSet)conList.arr[n]).ICount++;

                        }
                    }

                }

            }

            li.Add(new ItemSet());
            for (int i = 0; i < conList.Count; i++)
            {
                ItemSet con = (ItemSet)conList.arr[i];
                if (con.ICount >= support)
                {

                    ((ItemSet)li.arr[k]).Add(con);
                }


            }

            k++;
        }
        //for (int j = 0; j < li.Count; j++)
        //{
        //    for (int h = 0; h < li.Count; h++)
        //    {
        //        if (((ItemSet)li.arr[j]).Equals((ItemSet)li.arr[h]))
        //        {
        //            li.arr.RemoveAt(j);
        //            li.Count = li.arr.Count;
        //        }
        //    }
        //}
        for (int i = 0; i < li.Count; i++)
        {
            result.Add((ItemSet)li.arr[i]);
        }
        return result;



    }

    private ItemSet AprioriGenerate(ItemSet li, int k, double support)
    {

        ItemSet curList = null;
        ItemSet durList = null;
        ItemSet candi = null;
        ItemSet result = new ItemSet();
        for (int i = 0; i < li.Count; i++)
        {
            for (int j = 0; j < li.Count; j++)
            {
                bool flag = true;
                curList = (ItemSet)li.arr[i];
                durList = (ItemSet)li.arr[j];
                for (int n = 2; n < k; n++)
                {

                    if (((DataItem)curList.arr[n - 2]).Id == ((DataItem)durList.arr[n - 2]).Id)
                    {

                        flag = true;

                    }
                    else
                    {

                        flag = false;
                        break;


                    }


                }

                if (flag && ((DataItem)curList.arr[k - 1]).Id < ((DataItem)durList.arr[k - 1]).Id)
                {

                    flag = true;
                }
                else
                {
                    flag = false;
                }
                if (flag)
                {
                    candi = new ItemSet();


                    for (int m = 0; m < k; m++)
                    {
                        candi.Add((DataItem)durList.arr[m]);

                    }
                    candi.Add((DataItem)curList.arr[k - 1]);





                    if (HasInFrequentSubset(candi, li, k))
                    {
                        candi.Clear();

                    }
                    else
                    {
                        result.Add(candi);
                    }
                }

            }
        }
        return result;

    }



    private bool HasInFrequentSubset(ItemSet candidate, ItemSet li, int k)
    {
        ItemSet subSet = SubSet(candidate, k);
        ItemSet curList = null;
        ItemSet liCurList = null;

        for (int i = 0; i < subSet.Count; i++)
        {
            curList = (ItemSet)subSet.arr[i];
            for (int j = 0; j < li.Count; j++)
            {

                liCurList = (ItemSet)li.arr[j];
                if (liCurList.Equals(curList))
                {
                    return false;

                }

            }
        }
        return true; ;
    }
    //????    
    private ItemSet SubSet(ItemSet set)
    {
        ItemSet subSet = new ItemSet();

        ItemSet itemSet = new ItemSet();
        //???2n??    
        int num = 1 << set.Count;

        int bit;
        int mask = 0; ;
        for (int i = 0; i < num; i++)
        {
            itemSet = new ItemSet();
            for (int j = 0; j < set.Count; j++)
            {
                //mask?i??????????    
                mask = 1 << j;
                bit = i & mask;
                if (bit > 0)
                {

                    itemSet.Add((ItemSet)set.arr[j]);

                }
            }
            if (itemSet.Count > 0)
            {
                subSet.Add(itemSet);
            }


        }



        return subSet;
    }



    //????    
    private ItemSet SubSet(ItemSet set, int t)
    {
        ItemSet subSet = new ItemSet();

        ItemSet itemSet = new ItemSet();
        //???2n??    
        int num = 1 << set.Count;

        int bit;
        int mask = 0; ;
        for (int i = 0; i < num; i++)
        {
            itemSet = new ItemSet();
            for (int j = 0; j < set.Count; j++)
            {
                //mask?i??????????    
                mask = 1 << j;
                bit = i & mask;
                if (bit > 0)
                {

                    itemSet.Add((DataItem)set.arr[j]);

                }
            }
            if (itemSet.Count == t)
            {
                subSet.Add(itemSet);
            }


        }



        return subSet;
    }
}

public class DataItem
{
    public int Id;
    public string ItemName;
    public void Add(string item, int id)
    {
        ItemName = item;
        Id = id;
    }
}

public class ItemSet
{
    public int Count = 0;
    public int ICount = 0;
    public ArrayList arr = new ArrayList();
    public void Add(ItemSet input)
    {
        arr.Add(input);
        Count++;
    }
    public void Add(string input)
    {
        arr.Add(input);
        Count++;
    }
    public void Add(DataItem input)
    {
        arr.Add(input);
        Count++;
    }
    public void Sort()
    {
        DataItem temp = null;
        for (int i = 0; i < this.Count - 1; i++)
        {
            for (int j = i + 1; j < this.Count; j++)
            {
                if (((DataItem)this.arr[i]).Id > ((DataItem)this.arr[j]).Id)
                {
                    temp = (DataItem)this.arr[i];
                    this.arr[i] = this.arr[j];
                    this.arr[j] = temp;
                }
            }
        }
    }
    public bool Equals(ItemSet input)
    {
        if ((input.arr == null) || !(input.arr.GetType().Equals(this.arr.GetType())))
        {
            return false;
        }
        else if (input.arr.Count != this.arr.Count)
        {
            return false;
        }
        else
        {
            for (int i = 0; i < arr.Count; i++)
            {
                if (((DataItem)arr[i]).ItemName != ((DataItem)input.arr[i]).ItemName)
                    return false;
            }
            return true;
        }
    }
    public void Clear()
    {
        arr.Clear();
        Count = 0;
        ICount = 0;
    }
}

public class CSVReader
{
    public ItemSet Read(string file)
    {
        StreamReader csvfile = new StreamReader(file);
        ItemSet General = new ItemSet();
        ItemSet items = new ItemSet();
        DataItem set = new DataItem();
        string Line = "";
        string temp = "";
        int start = 0;
        int id = 0;
        int tcn = 0;
        Line = csvfile.ReadLine();

        while (!csvfile.EndOfStream)
        {

            Line = csvfile.ReadLine();
            tcn++;
            items = new ItemSet();

            while (Line.IndexOf(",") != -1)
            {
                set = new DataItem();
                temp = Line.Substring(0, Line.IndexOf(","));

                Line = Line.Substring(Line.IndexOf(",") + 1);
                set.Add(temp, id);
                items.Add(set);
                id++;
                start = Line.IndexOf(",");
            }
            temp = Line;
            set.Add(temp, id);
            items.Add(set);
            id = 0;
            temp = "";
            start = 0;
            General.Add(items);
        }
        //General.Add(items);
        Console.WriteLine("Total count"+General.Count);
        return General;
    }

}