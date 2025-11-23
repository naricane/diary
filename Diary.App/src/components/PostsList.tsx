import "./PostsList.css"
import type { PostDto } from "../dto/postDto";

interface Props {
  posts: PostDto[];
}

export default function PostsList({ posts }: Props) {
  return (
      <div className="post-list">
        {posts.map(post => (
          <div className="post-entry" key={post.id} >
            <h3>{new Date(post.createdAt).toLocaleDateString("en-US", {
              day: "2-digit",
              month: "short",
              year: "numeric"
            })}</h3>
            <p>{post.content}</p>

          </div>
        ))}
      </div>
  );
}
