using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorDataReader
{
  class CriteriaData
  {
    public string Usercode;
    public bool TooShort;
    public bool TooFar;
    public bool TooSlow;
    public bool TooFast;
    public string CorrectAnswers;
    public float Points;


    public CriteriaData() { }

    public CriteriaData(String username, List<int> bits, List<float> floatList, string bitString) {

      this.Usercode = username;

      this.TooShort = bits[2] == 1 ? true : false;
      this.TooFar = bits[3] == 1 ? true : false;
      this.TooSlow = bits[4] == 1 ? true : false;
      this.TooFast = bits[5] == 1 ? true : false;
      this.CorrectAnswers = bitString;

      this.Points = floatList[0];

    }

    public void ConvertSpeedData(Byte[] bytes)
    {
      string byteString = Utils.ByteArrayToString(bytes);

      double speed = 0;
      int[] bytelengthList = {4};
      int[] offsetList = {8};

      for (var i = 0; i < bytelengthList.Length; i++)
      {
        var hexString = byteString.Substring(8 + offsetList[i] * 2, bytelengthList[i]);
        if (hexString.Length == 2)
        {
        }
        else if (hexString.Length == 4)
        {

          var little = Utils.LittleEndian(hexString);
          string cut = little.Substring(0, 4);
          uint currentInt = Convert.ToUInt16(cut, 16);

          var curr = currentInt / 128f;
          speed = curr * 1.94384;
        }

      }
      var json = new { Content = speed, type = "speed" };
      string test_json = JsonConvert.SerializeObject(json);
      AsynchronousSocketListener.Send(test_json);
    }

    public void ConvertCriteriaData(Byte[] data)
    {
      List<float> floats = new List<float>();
      string byteString = Utils.ByteArrayToString(data);
      byte stops = data[20];
      
      int[] bytelengthList = {32, 2, 54, 8};
      int[] offsetList = { 0, 16, 17, 44,};
      string UserCode = "";
      string Bitstring = "";
      List<int> Bits = null;

      for (var i = 0; i < bytelengthList.Length; i++)
      {
        var hexString = byteString.Substring(8 + offsetList[i] * 2, bytelengthList[i]);
        if (hexString.Length == 32)
        {
          UserCode = Utils.ConvertHex(hexString);
        }
        else if(hexString.Length == 2)
        {
          Bits = Utils.GetBits(stops);
          Bitstring = Utils.GetBitString(stops);
        }
        else if (hexString.Length == 8)
        {
          int hexnumber = Convert.ToInt32(hexString, 16);
          var res = Utils.BitsToFloat(hexnumber);
          floats.Add(res);
        }

      }

      CriteriaData result = new CriteriaData(UserCode, Bits, floats, Bitstring);
      string json_send = result.ToString();

      var json = new { Content = json_send, type = "criteria" };
      string test_json = JsonConvert.SerializeObject(json);
      AsynchronousSocketListener.Send(test_json);
    }


    public override string ToString()
    {
      string json = JsonConvert.SerializeObject(this);
      return json;
    }

  }
}
