namespace FileReaderMultithread.FileClasses
{
    public interface FileOperationsInterface
    {
        object ReadFileToObject();
        int GetFileCountInDirectory(string workingDirectory);
    }
}
