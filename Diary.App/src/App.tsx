import { usePosts } from './hooks/usePost';
import './App.css'
import PostCreateForm from './components/PostCreateForm';
import PostsList from './components/PostsList';
import Loading from './components/Loading';

export default function App() {
  const { posts, isLoading, addPost } = usePosts();

  return (
    <>
      <h1>Diary</h1>

      <PostCreateForm onSubmit={addPost} />
      {isLoading ? <Loading /> : <PostsList posts={posts} />}
    </>
  )
}
