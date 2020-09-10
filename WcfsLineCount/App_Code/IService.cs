using System.Runtime.Serialization;
using System.ServiceModel;

[ServiceContract]
public interface IService
{

	[OperationContract]
	int LineCount(string filename);
}
