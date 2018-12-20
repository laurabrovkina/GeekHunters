export async function fetchCandidates() {
    const res = await fetch('/api/candidates');
    return await res.json();
}

export async function fetchSkills() {
    const res = await fetch('/api/skills');
    return await res.json();
}

export async function submitCandidate(firstName, lastName, skills) {
    const res = await fetch('/api/candidates', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ firstName, lastName, skills })
    });
    await res.text();
}