// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: enums.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace MeterReaderWeb.Services {

  /// <summary>Holder for reflection information generated from enums.proto</summary>
  public static partial class EnumsReflection {

    #region Descriptor
    /// <summary>File descriptor for enums.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static EnumsReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CgtlbnVtcy5wcm90byo2Cg1SZWFkaW5nU3RhdHVzEgsKB0lOVkFMSUQQABIL",
            "CgdTVUNDRVNTEAESCwoHRkFJTFVSRRACQhqqAhdNZXRlclJlYWRlcldlYi5T",
            "ZXJ2aWNlc2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::MeterReaderWeb.Services.ReadingStatus), }, null));
    }
    #endregion

  }
  #region Enums
  public enum ReadingStatus {
    [pbr::OriginalName("INVALID")] Invalid = 0,
    [pbr::OriginalName("SUCCESS")] Success = 1,
    [pbr::OriginalName("FAILURE")] Failure = 2,
  }

  #endregion

}

#endregion Designer generated code