using System.Collections.Generic;

public class KalmanData
{
	public float delta;
	public float q; //Experimental variable for best result
	public float value;
	public float previousValue;
}

public class KalmanFilter 
{

	static readonly List<KalmanData> data = new List<KalmanData>();

	public static int InitData(float delta, float q)
	{
		data.Add(new KalmanData() { delta = delta, q = q });
		return data.Count - 1;
	}

	public static void FreeData(int id)
	{
		if (id < 0)
			return;

		if (id >= data.Count)
			return;

		data.RemoveAt(id);

	}

	public static float GetValue(int id, float value)
	{
		float result = value;

		float pn = data[id].value + data[id].q;
		float gain = pn / (pn + data[id].delta);

		result = data[id].previousValue + gain * (value - data[id].previousValue);

		data[id].previousValue = result;
		data[id].value = (1 - gain) * pn;

		return result;
	}
}
