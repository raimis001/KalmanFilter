# KalmanFilter
KalmanFilter for Unity3D

Implementing simple Kalman Filter based on 
https://en.wikipedia.org/wiki/Kalman_filter#Underlying_dynamical_system_model

Using
int filterId;
float kalmanData;
void Start() 
{
  filterId = KalmanFilter.InitData(1, 1);
}

void Update() 
{
  kalmanData = KalmanFilter.GetValue(filterId, newData);
}
