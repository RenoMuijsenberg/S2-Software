import { FlatList, SafeAreaView, Text, TouchableHighlight, View} from 'react-native';
import {StatusBar} from "expo-status-bar";
import {useForm} from "react-hook-form";
import styles from "../styles/Main.styles"
import axios from "../Axios";
import React, {useEffect, useState} from "react";

function SchemeScreen({ navigation, route }) {
    const {control, handleSubmit, formState: { errors } } = useForm();
    const [exerciseArray, setExerciseArray] = useState([]);
    
    const scheme = route.params;

    const CreateNewExercise = async () => {
        navigation.navigate("Create exercise", scheme)
    };
    
    const startWorkout = async () => {
        navigation.navigate("Workout", {
            scheme, 
            "exercises": exerciseArray
        })
    };
    
    const GetAllWorkouts = navigation.addListener('focus', async () => {
        axios.get("exercise/get/" + scheme.id).then(response => {
            setExerciseArray(response.data.result)
        });
    });

    useEffect(async () => {
        await GetAllWorkouts;
    }, []);
    
    

    return (
        <SafeAreaView style={styles.container}>
            <StatusBar style="light"/>
            <View>
                <Text style={styles.headerText}>{scheme.name}</Text>
                <Text style={styles.smallText}>{scheme.note}</Text>
                <FlatList style={styles.listView} data={exerciseArray} renderItem={({item}) =>
                    <TouchableHighlight style={styles.buttonOutline}>
                        <Text style={styles.listText}>{item.name}</Text>
                    </TouchableHighlight>}
                />
            </View>
            <View>
                <TouchableHighlight style={styles.buttonOutline} onPress={startWorkout}>
                    <Text style={styles.buttonText}>Start workout</Text>
                </TouchableHighlight>
                <View style={styles.sideButtonContainer}>
                    <TouchableHighlight style={[styles.buttonOutline, styles.halfButton]} onPress={CreateNewExercise}>
                        <Text style={styles.buttonText}>Add excersise to scheme</Text>
                    </TouchableHighlight>
                    <TouchableHighlight style={[styles.buttonOutline, styles.halfButton]}>
                        <Text style={styles.buttonText}>Edit scheme</Text>
                    </TouchableHighlight>
                </View>
            </View>
        </SafeAreaView>
    );
}

export default SchemeScreen;