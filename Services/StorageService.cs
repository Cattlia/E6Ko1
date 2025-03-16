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

    // GET: Retrieve all notes
    public async Task<List<Note>> GetNotes()
    {
        return await _localStorage.GetItemAsync<List<Note>>(NotesKey) ?? new List<Note>();
    }

    // GET: Retrieve all folders
    public async Task<List<Folder>> GetFolders()
    {
        return await _localStorage.GetItemAsync<List<Folder>>(FoldersKey) ?? new List<Folder>();
    }

    // POST: Create a new note
    public async Task<Note> CreateNote(Note note)
    {
        var notes = await GetNotes();
        note.Id = notes.Count > 0 ? notes.Max(n => n.Id) + 1 : 1;
        notes.Add(note);
        await _localStorage.SetItemAsync(NotesKey, notes);
        return note;
    }

    // PUT: Update an existing note
    public async Task<Note> UpdateNote(Note note)
    {
        var notes = await GetNotes();
        var existingNote = notes.FirstOrDefault(n => n.Id == note.Id);
        if (existingNote != null)
        {
            existingNote.Text = note.Text;
            existingNote.FolderId = note.FolderId;
            await _localStorage.SetItemAsync(NotesKey, notes);
        }
        return existingNote ?? note;
    }

    // DELETE: Remove a note
    public async Task<bool> DeleteNote(int id)
    {
        var notes = await GetNotes();
        var removed = notes.RemoveAll(n => n.Id == id) > 0;
        if (removed)
        {
            await _localStorage.SetItemAsync(NotesKey, notes);
        }
        return removed;
    }

    // SAVE: Save the entire folders list
    public async Task SaveFolders(List<Folder> folders)
    {
        await _localStorage.SetItemAsync(FoldersKey, folders);
    }

    // SAVE: Save the entire notes list
    public async Task SaveNotes(List<Note> notes)
    {
        await _localStorage.SetItemAsync(NotesKey, notes);
    }

    // Clear all LocalStorage data
    public async Task ClearAllAsync()
    {
        await _localStorage.ClearAsync();
    }
}