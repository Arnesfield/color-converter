using System;

public class _color {

  private static readonly string[] CMDS = { "hex", "rgb", "help" };
  private static readonly int[] ARGS = { 2, 4, 1 };

  public static void Main(string[] args) {
    // first arg is command
    // 2 args hex
    // 4 args rgb

    if (args.Length == 0) {
      Console.WriteLine("Color Converter v1.0.0.");
      Console.WriteLine("(c) 2017 Arnesfield. All rights reserved.\n");
      d("Enter \"help\" for application arguments.");
      Environment.Exit(0);
    }

    if (!Array.Exists(CMDS, e => e == args[0])) {
      d("Error. \"" + args[0] + "\" is not a valid command.");
      Environment.Exit(0);
    }

    if (!Array.Exists(ARGS, e => e == args.Length)) {
      MsgError();
      Environment.Exit(0);
    }

    try {
      if (args.Length == ARGS[0] && args[0] == CMDS[0])
        HexToRGB(args);
      else if (args.Length == ARGS[1] && args[0] == CMDS[1])
        RGBToHex(args);
      else if (args.Length == ARGS[2] && args[0] == CMDS[2])
        Help();
      else
        throw new Exception();
    } catch (Exception e) { MsgError(); }
  }

  // hex
  private static void HexToRGB(string[] args) {
    try {
      string hex = args[1];
      if (!(hex.Length == 3 || hex.Length == 6))
        throw new Exception();

      if (hex.Length == 3) {
        string nHex = "";
        foreach (char c in hex)
          nHex += "" + c + "" + c;
        hex = nHex;
      }
      
      int[] rgb = new int[3];
      for (int i = 0, j = 0; i < 5; i+=2, j++) {
        string curr = hex[i] + "" + hex[i+1];
        rgb[j] = Convert.ToInt32(curr, 16);
        if (rgb[j] < 0 || rgb[j] > 255)
          throw new Exception();
        curr = "";
      }

      d("RGB: " + rgb[0] + ", " + rgb[1] + ", " + rgb[2]);
    } catch (Exception e) { MsgError(); }
  }

  // rgb
  private static void RGBToHex(string[] args) {
    try {
      string hex = "";
      for (int i = 1; i < 4; i++) {
        int n = Convert.ToInt32(args[i]);
        if (n < 0 || n > 255)
          throw new Exception();
        string t = n.ToString("X");
        hex += (t.Length == 1 ? "0" : "") + t;
      }

      d("Hex: #" + hex);
    } catch (Exception e) { MsgError(); }
  }

  // help
  private static void Help() {
    d("hex HEX");
    d("rgb INT INT INT");
  }

  private static void MsgError() {
    d("Error. Invalid argument/s or statement/s.");
  }

  private static void d(string s) {
    Console.WriteLine(":: color> " + s);
  }

}