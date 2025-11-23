import type { PostDto } from "../dto/PostDto";
import type { PostCreateDto } from "../dto/PostCreateDto";

const BASE_URL = "http://localhost:5130";

export async function getPosts(): Promise<PostDto[]> {
    const res = await fetch(`${BASE_URL}/posts`);
    if (!res.ok) {
        throw new Error("Failed to load posts");
    }
    return res.json();
}

export async function createPost(req: PostCreateDto): Promise<PostDto> {
    const res = await fetch(`${BASE_URL}/posts`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(req)
    });

    if (!res.ok) {
        throw new Error("Failed to create post");
    }

    return res.json();
}
