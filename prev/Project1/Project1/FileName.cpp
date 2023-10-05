#include<iostream>

using namespace std;

int main()
{
	int arr[100] = {};
	int N,M,i, j, k;

	cin >> N >> M;
	int a = 0;

	
	while (a < M)
	{
		cin >> i >> j >> k;

		for (int b = i; b <= j; b++)
			arr[b-1] = k;

		a++;
	}
	
	for (int i = 0; i < N ; i++)
	{
		cout << arr[i]<<" ";
	}

	return 0;
}