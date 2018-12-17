export async function fetchCandidates() {
    const res = await fetch('/api/candidate');
    return await res.json();
}