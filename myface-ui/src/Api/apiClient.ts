export interface ListResponse<T> {
  items: T[];
  totalNumberOfItems: number;
  page: number;
  nextPage: string;
  previousPage: string;
}

export interface User {
  id: number;
  firstName: string;
  lastName: string;
  displayName: string;
  username: string;
  email: string;
  profileImageUrl: string;
  coverImageUrl: string;
}

export interface Interaction {
  id: number;
  user: User;
  type: string;
  date: string;
}

export interface Post {
  id: number;
  message: string;
  imageUrl: string;
  postedAt: string;
  postedBy: User;
  likes: Interaction[];
  dislikes: Interaction[];
}

export interface NewPost {
  message: string;
  imageUrl: string;
  userId: number;
}

export async function fetchUsers(
  searchTerm: string,
  page: number,
  pageSize: number,
  header: string
): Promise<ListResponse<User>> {
  const response = await fetch(
    `https://localhost:5001/users?search=${searchTerm}&page=${page}&pageSize=${pageSize}`,
    {
      headers: {
        "Authorization": `Basic ${header}`,
      },
    }
  );
  return await response.json();
}

export async function fetchUser(userId: string | number, header: string): Promise<User> {
  const response = await fetch(`https://localhost:5001/users/${userId}`, {
    headers: {
      "Authorization": `Basic ${header}`,
    },
  });
  return await response.json();
}

export async function fetchUserByUsername(username: string, header: string): Promise<User> {
  const response = await fetch(`https://localhost:5001/users/username/${username}`, {
    headers: {
      "Authorization": `Basic ${header}`,
    },
  });
  return await response.json();
}

export async function fetchPosts(
  page: number,
  pageSize: number,
  header: string
): Promise<ListResponse<Post>> {
  const response = await fetch(
    `https://localhost:5001/feed?page=${page}&pageSize=${pageSize}`,
    {
      headers: {
        "Authorization": `Basic ${header}`,
      },
    }
  );
  return await response.json();
}

export async function fetchPostsForUser(
  page: number,
  pageSize: number,
  userId: string | number,
  header: string
) {
  const response = await fetch(
    `https://localhost:5001/feed?page=${page}&pageSize=${pageSize}&postedBy=${userId}`,
    {
      headers: {
        "Authorization": `Basic ${header}`,
      },
    }
  );
  return await response.json();
}

export async function fetchPostsLikedBy(
  page: number,
  pageSize: number,
  userId: string | number,
  header: string
) {
  const response = await fetch(
    `https://localhost:5001/feed?page=${page}&pageSize=${pageSize}&likedBy=${userId}`,
    {
      headers: {
        "Authorization": `Basic ${header}`,
      },
    }
  );
  return await response.json();
}

export async function fetchPostsDislikedBy(
  page: number,
  pageSize: number,
  userId: string | number,
  header: string
) {
  const response = await fetch(
    `https://localhost:5001/feed?page=${page}&pageSize=${pageSize}&dislikedBy=${userId}`,
    {
      headers: {
        "Authorization": `Basic ${header}`,
      },
    }
  );
  return await response.json();
}

export async function createPost(newPost: NewPost, header: string) {
  const response = await fetch(`https://localhost:5001/posts/create`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      "Authorization": `Basic ${header}`
    },
    body: JSON.stringify(newPost),
  });

  if (!response.ok) {
    throw new Error(await response.json());
  }
}
