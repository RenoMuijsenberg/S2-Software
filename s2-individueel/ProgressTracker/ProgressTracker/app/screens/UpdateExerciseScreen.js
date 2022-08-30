import {Alert, FlatList, SafeAreaView, Text, TouchableHighlight, View} from 'react-native';
import {StatusBar} from "expo-status-bar";
import styles from "../styles/Main.styles"
import React, {useEffect, useState} from "react";
import {useForm} from "react-hook-form";
import Input from "../components/Input";
import axios from "../Axios";

function UpdateExerciseScreen({ navigation, route }) {
    const {control, handleSubmit, formState: { errors } } = useForm();
    const [inputsArray, setInputsArray] = useState([]);
    const [setArray, setSetArray] = useState([]);
    
    const exercise = route.params;

    const UpdateExercise = async (data) => {
        data.id = exercise.id;

        await axios.post("set/create", JSON.stringify(data)).then(response =>{
            Alert.alert("Success", response.data.userMessage);
            navigation.goBack();
        });
    };
    
    const GetPreviouseSets = async () => {
        axios.get("set/get/" + exercise.id).then(response => {
            setSetArray(response.data.result)
        });
    };
    
    const inputs = [];

    const CreateInputs = async () => {
        for (let i = 0; i < exercise.sets; i++) {
            const name = "Weight-"+i;
            inputs.push(
                <View key={name}>
                    <Input label={"Set " + (i + 1)} name={name} required={false} control={control}/>
                    {errors[name] && <Text style={styles.error}>{errors[name].message}</Text>}
                </View>
            )
        }
    };

    useEffect(async () => {
        await GetPreviouseSets();
        await CreateInputs();
        await setInputsArray(inputs);
    }, []);

    return (
        <SafeAreaView style={styles.container}>
            <StatusBar style="light"/>
            <View>
                <Text style={styles.headerText}>{exercise.name}</Text>
                <Text style={styles.smallText}>{exercise.note}</Text>
                <View style={[styles.splitViewContainer, styles.buttonOutline]}>
                    <View style={styles.splitView}>
                    {/*  prev data  */}
                        <Text style={styles.smallHeaderText}>Prev data:</Text>
                        <FlatList style={styles.listView} data={setArray} renderItem={({item, index}) =>
                            <View>
                                <Text style={styles.setText}>Set {index +1}:</Text>
                                <Text style={styles.setDataText}>{item.set}</Text>
                            </View>
                        }/>
                    </View>
                    <View style={styles.splitView}>
                        <Text style={styles.smallHeaderText}>New data:</Text>
                        {inputsArray}
                    </View>
                </View>
            </View>
            <View>
                <TouchableHighlight style={styles.buttonOutline} onPress={handleSubmit(UpdateExercise)}>
                    <Text style={styles.buttonText}>Save exercise sets</Text>
                </TouchableHighlight>
            </View>
        </SafeAreaView>
    );
}

export default UpdateExerciseScreen;