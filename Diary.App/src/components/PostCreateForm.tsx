import { useState, useRef, useEffect } from "react";
import './PostCreateForm.css'

interface Props {
  onSubmit: (text: string) => void;
}

export default function PostCreateForm({ onSubmit }: Props) {
  const [text, setText] = useState("");
  const textareaRef = useRef<HTMLTextAreaElement>(null);

  useEffect(() => {
    const el = textareaRef.current;
    if (!el) {
      return;
    }

    el.style.height = "auto";
    el.style.height = el.scrollHeight + "px";

    console.log(el.scrollHeight)
  }, [text]);

  return (
      <div className="post-create-form">
        <textarea
          placeholder="What's on your mind?"
          ref={textareaRef}
          value={text}
          onChange={e => setText(e.target.value)}
        />
        <button onClick={() => {
          if (text.trim() === "") {
            return;
          }
          onSubmit(text);
          setText("");
        }}>
          Post
        </button>
      </div>
  );
}
