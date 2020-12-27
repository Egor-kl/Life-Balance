import  { ACTION_TYPES } from '../actions/diary';
const initialState = {
    list: []
}

export const diary = (state = initialState, action) => {
    
    switch (action.type) {
        case ACTION_TYPES.FETCH_ALL:
            return {
                ...state,
                list: [...action.payload]
            }

        case ACTION_TYPES.CREATE:
            return {
                ...state,
                list: [...state.list, action.payload]
            }

        case ACTION_TYPES.UPDATE:
            return {
                ...state,
                list: state.list.map(x => x.id == action.payload.id ? action.payload : x)
            }

        case ACTION_TYPES.DELETE:
            return {
                ...state,
                list: state.list.filter(x => x.id != action.payload)
            }
        case ACTION_TYPES.FETCH_BY_ID:
            return {
                ...state,
                list: [...state.list, action.payload]
            }
            
        default:
            return state
    }
}