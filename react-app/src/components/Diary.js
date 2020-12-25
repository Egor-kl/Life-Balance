import React, {useState, useEffect} from 'react';
import { connect } from 'react-redux';
import * as actions from "../actions/diary";

const Diary = (props) => {
    

    

    return(
        <div>diary not form</div>
    )
}

const mapStateToProps = state => ({
    diaryList: state.diary.diaryList
})

const mapActionToProps = state => {
    fetchalldiary: actions.fetchAll()
}

export default connect(mapStateToProps, mapActionToProps)(Diary);