

import { Button } from 'antd'
import { HeartOutlined, HeartFilled } from '@ant-design/icons'
import { Fragment } from 'react';

const LikeButton = (props) => {
    let { likeArticle, likes } = props;
    return (
        <Fragment>
            <Button type="primary" onClick={likeArticle} icon={likes > 0 ? <HeartFilled /> : <HeartOutlined />}> {likes}</Button>
        </Fragment>
    )
}

export default LikeButton;