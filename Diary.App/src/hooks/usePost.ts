import { useEffect, useState } from "react";
import { getPosts, createPost } from "../api/postsApi";
import type { PostDto } from "../dto/postDto";

export function usePosts() {
    const [posts, setPosts] = useState<PostDto[]>([]);
    const [isLoading, setLoading] = useState(true);

    useEffect(() => {
        load();
    }, []);

    async function load() {
        setLoading(true);
        const data = await getPosts();
        setPosts(data);
        setLoading(false);
    }

    async function addPost(content: string) {
        const newPost = await createPost({ content });
        setPosts(prev => [newPost, ...prev]);
    }

    return {
        posts,
        isLoading,
        addPost,
        reload: load
    };
}
