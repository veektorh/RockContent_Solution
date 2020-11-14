


import { request } from "./fetchrequest";

const getArticles = async () => {
    return await request.get('/articles');
}

const likePost = async (id) => {
    return await request.post(`/articles/like/${id}`, {});
}


export const articleService = {
    getArticles,
    likePost
}