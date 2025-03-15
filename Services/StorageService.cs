using Blazored.LocalStorage;
using E6Ko.Models;

namespace E6Ko.Services;

public class StorageService
{
    private readonly ILocalStorageService _localStorage;
    private const string FoldersKey = "folders";
    private const string NotesKey = "notes";

    public StorageService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<List<Folder>> GetFoldersAsync()
    {
        var folders = await _localStorage.GetItemAsync<List<Folder>>(FoldersKey);
        return folders ?? new List<Folder>();
    }

    public async Task<List<Note>> GetNotesAsync()
    {
        var notes = await _localStorage.GetItemAsync<List<Note>>(NotesKey);
        return notes ?? new List<Note>();
    }

    public async Task SaveFoldersAsync(List<Folder> folders)
    {
        await _localStorage.SetItemAsync(FoldersKey, folders);
    }

    public async Task SaveNotesAsync(List<Note> notes)
    {
        await _localStorage.SetItemAsync(NotesKey, notes);
    }

    public async Task ClearAllAsync()
    {
        await _localStorage.ClearAsync();
    }
}