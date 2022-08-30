import {FlatList, SafeAreaView, Text, TouchableHighlight, View} from 'react-native';
import {StatusBar} from "expo-status-bar";
import styles from "../styles/Main.styles"
import React from "react";

function WorkoutScreen({ navigation, route }) {
    const scheme = route.params.scheme;
    const exercises = route.params.exercises;

    const SelectExercise = (exercise) => {
        navigation.navigate("Update exercise", exercise)
    };
    
    return (
        <SafeAreaView style={styles.container}>
            <StatusBar style="light"/>
            <View>
                <Text style={styles.headerText}>{scheme.name}</Text>
                <Text style={styles.smallText}>{scheme.note}</Text>
                <FlatList style={styles.listView} data={exercises} renderItem={({item}) =>
                    <TouchableHighlight style={styles.buttonOutline} onPress={() => SelectExercise(item)}>
                        <View>
                            <Text style={styles.listText}>{item.name}</Text>
                            <Text style={styles.smallListText}>{item.note}</Text>
                        </View>
                    </TouchableHighlight>}
                />
            </View>
            <View>
                <Text style={styles.smallListText}>Click on an excersise to update</Text>
            </View>
        </SafeAreaView>
    );
}

export default WorkoutScreen;