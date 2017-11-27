import * as PostActions from './post.actions';
import { Post } from './post.model';
import { SwitchView } from '@angular/common/src/directives/ng_switch';

export type Action = PostActions.All;

// set to default state when reset
const defaultState: Post = {
    text: 'Hello. Default post.',
    likes: 0
};

const newState = (state, newData) => {
    return Object.assign({}, state, newData);
};

export function postReducer(state: Post = defaultState, action: Action) {
    console.log(action.type, state);

    switch (action.type) {
        case PostActions.EDIT_TEXT:
            return newState(state, { text: action.payload });
        case PostActions.UPVOTE:
            return newState(state, { likes: state.likes + 1 });
        case PostActions.DOWNVOTE:
            return newState(state, { likes: state.likes - 1 });
        case PostActions.RESET:
            return defaultState;
        default:
            return state;
    }
}
