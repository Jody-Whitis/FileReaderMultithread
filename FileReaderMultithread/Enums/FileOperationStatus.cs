namespace FileReaderMultithread.Enums
{
    public enum FileOperationStatus
    {
        FileError = -1,
        DefaultStatus = 0,
        FileMoved = 1,
        FileDeleted = 2,
        FileModified = 3,
        FileDestinationExistsNotMoved = 4,
        FileDestinationExistsDeleted = 5,
        FileSourceDoesNotExists = 6,
        FileCopied = 7,
        FileCreated = 8,
        FileOpened = 9,
        FileClosed = 10
    }
}
