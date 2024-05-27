using System;
using Bam.Data;

namespace Bam.Configuration
{
    // TODO: create an inheriting interface IYamlFilePersistable
    public interface IFilePersistable: IHasUniversalDeterministicId
    {
        SerializationFormat Format { get; set; }
        void Save(string filePath);
        void Load(Type type, string filePath);
        //void LoadYaml(Type type, string filePath);
        void LoadJson(Type type, string filePath);
        //void LoadXml(Type type, string filePath);
        //void LoadBinary(Type type, string filePath);
    }
}