import api from "./api";

export const ACTION_TYPES = {
    CREATE: 'CREATE',
    UPDATE: 'UPDATE',
    DELETE: 'DELETE',
    FETCH_ALL: 'FETCH_ALL',
    FETCH_BY_ID: 'FETCH_BY_ID'
}

export const fetchAll = () => dispatch => {
    api.diary().fetchAll()
        .then(response => {
            console.log(response);
            dispatch({
                type: ACTION_TYPES.FETCH_ALL,
                payload: response.data
            })
        })
        .catch(err => console.log(err))
}

export const Delete = (id, onSuccess) => dispatch => {
    api.diary().delete(id)
        .then(res => {
            dispatch({
                type: ACTION_TYPES.DELETE,
                payload: id
            })
            onSuccess()
        })
        .catch(err => console.log(err))
}

export const Create = (data, onSuccess) => dispatch => {
    api.diary().create(data)
        .then(res => {
            dispatch({
                type: ACTION_TYPES.CREATE,
                payload: res.data
            })
            onSuccess()
        })
        .catch(err => console.log(err))
}

export const Update = (id, data, onSuccess) => dispatch => {
    api.diary().update(id, data)
        .then(res => {
            dispatch({
                type: ACTION_TYPES.UPDATE,
                payload: { id, ...data }
            })
            onSuccess()
        })
        .catch(err => console.log(err))
}

export const fetchById = (id) => dispatch => {
    api.diary().fetchById(id)
        .then(response => {
            dispatch({
                type: ACTION_TYPES.FETCH_BY_ID,
                payload: response.data
            })
        })
        .catch(err => console.log(err))
}