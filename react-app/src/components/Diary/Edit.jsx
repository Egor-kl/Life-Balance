import React, {useEffect, useState} from "react";
import * as actions from "../../actions/diary";
import {connect} from "react-redux";
import {useToasts} from "react-toast-notifications";

const Edit = (props) => {
    const [, setCount] = useState(0);

    useEffect(() => {
        props.updateEntry(props.location.state.id)
    }, [])

    const { addToast } = useToasts()

    const update = (id, data) => {
        console.log(data[0]);
        if (window.confirm('Are you sure to update this record?'))
            props.updateEntry(id, data[0], ()=> addToast("Update successfully", { appearance: 'info' }))
    }

    console.log(props);

    return(
        <div className="content">
            <div className="background">
                <div className="container">
                    <div className="diary__block">
                        <div className="diary__field1">
                            <div className="title1">
                                <p>TITLE</p>
                            </div>
                            <div className="textarea1">
                                <textarea className="title" defaultValue={props.location.state.title}></textarea>
                            </div>
                        </div>
                        <div className="diary__field2">
                            <div className="title2">
                                <p>ENTRIES</p>
                            </div>
                            <div className="textarea2">
                                <textarea className="notes" defaultValue={props.location.state.entries} ></textarea>
                            </div>
                        </div>
                        <div className="button">
                            <button onClick={() => update(props.match.params.id, props.diaryList)} type="submit" className="button__button">
                                UPDATE
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

const mapStateToProps = state => ({
    diaryList: state.diary.list
})

const mapActionToProps = {
    fetchById: actions.fetchById,
    updateEntry: actions.Update
}

export default connect(mapStateToProps, mapActionToProps)(Edit);